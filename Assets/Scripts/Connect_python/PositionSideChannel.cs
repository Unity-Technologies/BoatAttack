using System;
using System.Collections.Generic;
using Unity.MLAgents.SideChannels;
using UnityEngine;

/// <summary>
/// Unity에서 Python으로 객체 위치 정보를 전송하는 커스텀 Side Channel
/// </summary>
public class PositionSideChannel : SideChannel
{
    private Dictionary<string, Vector3> positionData = new Dictionary<string, Vector3>();
    private object dataLock = new object();
    private static bool hasLoggedFirstMessage = false;

    public PositionSideChannel()
    {
        ChannelId = new Guid("621f0a70-4f87-11d2-a976-00c04f8e1488");
    }

    /// <summary>
    /// 객체 위치를 설정
    /// </summary>
    public void SetPosition(string objectName, Vector3 position)
    {
        lock (dataLock)
        {
            positionData[objectName] = position;
        }
    }

    /// <summary>
    /// 현재 저장된 위치 데이터를 가져옴
    /// </summary>
    public Dictionary<string, Vector3> GetPositions()
    {
        lock (dataLock)
        {
            return new Dictionary<string, Vector3>(positionData);
        }
    }

    /// <summary>
    /// Python에서 Unity로 메시지를 보낼 때 사용 (현재는 불필요)
    /// </summary>
    protected override void OnMessageReceived(IncomingMessage msg)
    {
        // Python에서 Unity로 메시지를 보낼 때 사용
    }

    /// <summary>
    /// 저장된 모든 위치 데이터를 Python으로 전송
    /// </summary>
    public void SendPositionsToPython()
    {
        lock (dataLock)
        {
            if (positionData.Count > 0)
            {
                using (var msgOut = new OutgoingMessage())
                {
                    // 메시지 형식: [객체 개수] [객체1 이름] [x] [y] [z] [객체2 이름] [x] [y] [z] ...
                    msgOut.WriteInt32(positionData.Count);
                    foreach (var kvp in positionData)
                    {
                        msgOut.WriteString(kvp.Key);
                        msgOut.WriteFloat32(kvp.Value.x);
                        msgOut.WriteFloat32(kvp.Value.y);
                        msgOut.WriteFloat32(kvp.Value.z);
                    }
                    
                    // 중요: QueueMessageToSend는 Unity ML-Agents가 env.step() 호출 시 메시지를 전송합니다.
                    // 하지만 Unity C#에서 생성한 Side Channel이 Python과 연결되지 않으면 메시지가 전달되지 않습니다.
                    QueueMessageToSend(msgOut);
                    
                    // 디버깅: 첫 메시지 전송 시 로그 출력
                    if (!hasLoggedFirstMessage)
                    {
                        Debug.Log($"[PositionSideChannel] ✅ 첫 메시지 전송 시도! 객체 수: {positionData.Count}, ChannelId: {ChannelId}");
                        Debug.Log($"[PositionSideChannel] ⚠️ Python의 on_message_received가 호출되는지 확인하세요!");
                        foreach (var kvp in positionData)
                        {
                            Debug.Log($"  - {kvp.Key}: ({kvp.Value.x:F2}, {kvp.Value.y:F2}, {kvp.Value.z:F2})");
                        }
                        hasLoggedFirstMessage = true;
                    }
                }
            }
            else
            {
                // 디버깅: 데이터가 없을 때도 로그 출력
                if (Time.frameCount % 120 == 0) // 약 2초마다
                {
                    Debug.LogWarning($"[PositionSideChannel] 위치 데이터가 없습니다! (Count: {positionData.Count})");
                }
            }
        }
    }
}

