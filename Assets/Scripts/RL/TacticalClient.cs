using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// Unity → Roonshot 전술 서버 TCP 클라이언트
    /// 전장 데이터를 전송하고, 배정 결과를 수신합니다.
    /// </summary>
    public class TacticalClient : MonoBehaviour
    {
        [Header("Connection")]
        [Tooltip("전술 서버 호스트")]
        public string host = "localhost";

        [Tooltip("전술 서버 포트")]
        public int port = 9877;

        [Tooltip("자동 연결 시도")]
        public bool autoConnect = true;

        [Header("Data Sources")]
        [Tooltip("방어 환경 컨트롤러")]
        public DefenseEnvController envController;

        [Header("Send Settings")]
        [Tooltip("전장 데이터 전송 주기 (초)")]
        public float sendInterval = 0.1f;

        [Header("Status (Read Only)")]
        [SerializeField] private bool _isConnected = false;
        [SerializeField] private string _lastAssignment = "";

        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _receiveThread;
        private volatile bool _running = false;
        private float _lastSendTime = 0f;
        private string _recvBuffer = "";

        // 수신 큐 (메인 스레드에서 처리)
        private readonly Queue<string> _receiveQueue = new Queue<string>();
        private readonly object _queueLock = new object();

        // 최신 배정 결과
        private TacticalAssignment _latestAssignment;
        private readonly object _assignmentLock = new object();

        public bool IsConnected => _isConnected;

        /// <summary>
        /// 최신 배정 결과 가져오기
        /// </summary>
        public TacticalAssignment GetLatestAssignment()
        {
            lock (_assignmentLock)
            {
                return _latestAssignment;
            }
        }

        private void Start()
        {
            if (autoConnect)
            {
                Connect();
            }
        }

        private void OnDestroy()
        {
            Disconnect();
        }

        public void Connect()
        {
            if (_isConnected) return;

            try
            {
                _client = new TcpClient();
                _client.Connect(host, port);
                _stream = _client.GetStream();
                _isConnected = true;
                _running = true;

                _receiveThread = new Thread(ReceiveLoop) { IsBackground = true };
                _receiveThread.Start();

                Debug.Log($"[TacticalClient] Connected to {host}:{port}");
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[TacticalClient] Connection failed: {e.Message}");
                _isConnected = false;
            }
        }

        public void Disconnect()
        {
            _running = false;
            _isConnected = false;

            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }

            Debug.Log("[TacticalClient] Disconnected");
        }

        private void FixedUpdate()
        {
            if (!_isConnected) return;

            // 전장 데이터 전송
            if (Time.time - _lastSendTime >= sendInterval)
            {
                _lastSendTime = Time.time;
                SendBattlefieldData();
            }

            // 수신 큐 처리
            ProcessReceiveQueue();
        }

        /// <summary>
        /// 전장 데이터 JSON 생성 및 전송
        /// </summary>
        private void SendBattlefieldData()
        {
            if (envController == null) return;

            var data = new BattlefieldData();
            data.time = Time.time;
            data.frame = Time.frameCount;

            // 모선
            if (envController.motherShip != null)
            {
                var msPos = envController.motherShip.transform.position;
                data.mothership = new ShipInfo { x = msPos.x, z = msPos.z };
            }

            // 아군
            data.friendlies = new List<ShipInfo>();
            if (envController.defenseAgent1 != null)
            {
                data.friendlies.Add(GetShipInfo(envController.defenseAgent1.gameObject, "Friendly_0",
                    envController.defenseAgent2 != null ? "Friendly_1" : ""));
            }
            if (envController.defenseAgent2 != null)
            {
                data.friendlies.Add(GetShipInfo(envController.defenseAgent2.gameObject, "Friendly_1",
                    envController.defenseAgent1 != null ? "Friendly_0" : ""));
            }

            // 적군
            data.enemies = new List<ShipInfo>();
            if (envController.enemyShips != null)
            {
                for (int i = 0; i < envController.enemyShips.Length; i++)
                {
                    var enemy = envController.enemyShips[i];
                    if (enemy != null)
                    {
                        var info = GetShipInfo(enemy, $"Enemy_{i}");
                        info.active = enemy.activeInHierarchy;
                        data.enemies.Add(info);
                    }
                }
            }

            string json = JsonUtility.ToJson(data) + "\n";
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                _stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception)
            {
                Disconnect();
            }
        }

        private ShipInfo GetShipInfo(GameObject obj, string id, string pairId = "")
        {
            var pos = obj.transform.position;
            var info = new ShipInfo
            {
                id = id,
                x = pos.x,
                z = pos.z,
                heading = obj.transform.eulerAngles.y,
                active = obj.activeInHierarchy,
                pair_id = pairId
            };

            var rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                info.vx = rb.velocity.x;
                info.vz = rb.velocity.z;
                info.speed = rb.velocity.magnitude;
            }

            return info;
        }

        /// <summary>
        /// 수신 스레드
        /// </summary>
        private void ReceiveLoop()
        {
            byte[] buffer = new byte[8192];
            while (_running)
            {
                try
                {
                    if (_stream == null || !_stream.CanRead) break;

                    int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    _recvBuffer += data;

                    while (_recvBuffer.Contains("\n"))
                    {
                        int idx = _recvBuffer.IndexOf('\n');
                        string line = _recvBuffer.Substring(0, idx).Trim();
                        _recvBuffer = _recvBuffer.Substring(idx + 1);

                        if (!string.IsNullOrEmpty(line))
                        {
                            lock (_queueLock)
                            {
                                _receiveQueue.Enqueue(line);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    if (_running) Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// 메인 스레드에서 수신 큐 처리
        /// </summary>
        private void ProcessReceiveQueue()
        {
            lock (_queueLock)
            {
                while (_receiveQueue.Count > 0)
                {
                    string json = _receiveQueue.Dequeue();
                    ParseAssignment(json);
                }
            }
        }

        private void ParseAssignment(string json)
        {
            try
            {
                var result = JsonUtility.FromJson<TacticalAssignment>(json);
                if (result != null && result.type == "assignment")
                {
                    lock (_assignmentLock)
                    {
                        _latestAssignment = result;
                    }
                    _lastAssignment = $"{result.formation} ({result.confidence:F1}%)";
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[TacticalClient] Parse error: {e.Message}");
            }
        }
    }

    // JSON 직렬화 클래스들
    [Serializable]
    public class ShipInfo
    {
        public string id;
        public float x;
        public float z;
        public float vx;
        public float vz;
        public float heading;
        public float speed;
        public bool active = true;
        public string pair_id = "";
    }

    [Serializable]
    public class BattlefieldData
    {
        public float time;
        public int frame;
        public ShipInfo mothership;
        public List<ShipInfo> friendlies;
        public List<ShipInfo> enemies;
    }

    [Serializable]
    public class TacticalAssignment
    {
        public string type;
        public string formation;
        public float confidence;
        public int num_clusters;
        public AssignmentEntry[] assignments;
    }

    [Serializable]
    public class AssignmentEntry
    {
        public string[] pair;
        public string target_enemy_id;
        public int cluster_id;
    }
}
