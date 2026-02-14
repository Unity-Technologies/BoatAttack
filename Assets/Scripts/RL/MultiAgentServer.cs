using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

[Serializable]
public class ShipData
{
    public string id;
    public string tag;
    public float[] position;
    public float[] velocity;
    public float[] rotation;
    public float speed;
}

[Serializable]
public class MultiAgentMessage
{
    public List<ShipData> ships = new List<ShipData>();
    public int frameCount;
    public float time;
}

[Serializable]
public class ActionMessage
{
    public string shipId;
    public float throttle;
    public float steering;
    public bool fire;
}

public class MultiAgentServer : MonoBehaviour
{
    [Header("Server Settings")]
    public int port = 9876;

    [Header("Ship Detection")]
    public string[] shipTags = { "Friendly", "attack_boat", "MotherShip" };
    public float sendInterval = 0.1f;

    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;
    private Thread serverThread;
    private Thread receiveThread;

    private bool isRunning = false;
    private object lockObj = new object();

    private Queue<ActionMessage> actionQueue = new Queue<ActionMessage>();

    private float nextSendTime;
    private int frameCounter = 0;

    void Start()
    {
        StartServer();
        nextSendTime = Time.time;
    }

    void OnDestroy() { StopServer(); }

    void Update()
    {
        lock (lockObj)
        {
            while (actionQueue.Count > 0)
            {
                ActionMessage action = actionQueue.Dequeue();
                ApplyAction(action);
            }
        }
    }

    void FixedUpdate()
    {
        if (Time.time >= nextSendTime && client != null && client.Connected)
        {
            SendAllShipsData();
            nextSendTime = Time.time + sendInterval;
            frameCounter++;
        }
    }

    private void StartServer()
    {
        isRunning = true;
        serverThread = new Thread(ServerLoop);
        serverThread.IsBackground = true;
        serverThread.Start();
        Debug.Log($"[MultiAgentServer] Server started on port {port}");
    }

    private void StopServer()
    {
        isRunning = false;
        if (stream != null) try { stream.Close(); } catch { }
        if (client != null) try { client.Close(); } catch { }
        if (listener != null) try { listener.Stop(); } catch { }
        if (serverThread != null && serverThread.IsAlive) serverThread.Join(1000);
        if (receiveThread != null && receiveThread.IsAlive) receiveThread.Join(1000);
        Debug.Log("[MultiAgentServer] Server stopped");
    }

    private void ServerLoop()
    {
        try
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Debug.Log($"[MultiAgentServer] Listening on port {port}...");

            while (isRunning)
            {
                if ((client == null || !client.Connected) && listener.Pending())
                {
                    CleanupClient();
                    client = listener.AcceptTcpClient();
                    stream = client.GetStream();
                    Debug.Log("[MultiAgentServer] Client connected!");

                    if (receiveThread != null && receiveThread.IsAlive)
                        receiveThread.Join(500);
                    receiveThread = new Thread(ReceiveLoop);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }
                Thread.Sleep(100);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"[MultiAgentServer] Server error: {e.Message}");
        }
    }

    private void ReceiveLoop()
    {
        byte[] buffer = new byte[4096];
        try
        {
            while (isRunning && client != null && client.Connected)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;
                if (bytesRead > 0)
                {
                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    try
                    {
                        ActionMessage action = JsonUtility.FromJson<ActionMessage>(json);
                        lock (lockObj) { actionQueue.Enqueue(action); }
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"[MultiAgentServer] JSON parse error: {e.Message}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"[MultiAgentServer] Receive error: {e.Message}");
        }
        finally
        {
            CleanupClient();
        }
    }

    private void SendAllShipsData()
    {
        if (stream == null || !stream.CanWrite) return;
        if (client == null || !client.Connected) { CleanupClient(); return; }

        try
        {
            MultiAgentMessage msg = new MultiAgentMessage();
            msg.frameCount = frameCounter;
            msg.time = Time.time;

            foreach (string tagName in shipTags)
            {
                GameObject[] ships = GameObject.FindGameObjectsWithTag(tagName);
                foreach (GameObject ship in ships)
                {
                    ShipData shipData = CollectShipData(ship, tagName);
                    if (shipData != null) msg.ships.Add(shipData);
                }
            }

            string json = JsonUtility.ToJson(msg);
            byte[] data = Encoding.UTF8.GetBytes(json + "\n");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
        catch (Exception e)
        {
            Debug.LogWarning($"[MultiAgentServer] Send error: {e.Message}");
            CleanupClient();
        }
    }

    private void CleanupClient()
    {
        try
        {
            if (stream != null) { stream.Close(); stream = null; }
            if (client != null) { client.Close(); client = null; }
        }
        catch { }
    }

    private ShipData CollectShipData(GameObject ship, string tag)
    {
        if (ship == null) return null;
        ShipData data = new ShipData();
        data.id = ship.name;
        data.tag = tag;
        data.position = new float[] { ship.transform.position.x, ship.transform.position.y, ship.transform.position.z };
        data.rotation = new float[] { ship.transform.eulerAngles.x, ship.transform.eulerAngles.y, ship.transform.eulerAngles.z };

        Rigidbody rb = ship.GetComponent<Rigidbody>();
        if (rb != null)
        {
            data.velocity = new float[] { rb.velocity.x, rb.velocity.y, rb.velocity.z };
            data.speed = rb.velocity.magnitude;
        }
        else
        {
            data.velocity = new float[] { 0, 0, 0 };
            data.speed = 0f;
        }
        return data;
    }

    private void ApplyAction(ActionMessage action)
    {
        GameObject ship = GameObject.Find(action.shipId);
        if (ship == null) return;

        var boat = ship.GetComponent<BoatAttack.Boat>();
        if (boat != null && boat.engine != null)
        {
            boat.engine.Accelerate(action.throttle);
            boat.engine.Turn(action.steering);
        }
    }
}
