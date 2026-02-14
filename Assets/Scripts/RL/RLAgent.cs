using System;
using UnityEngine;

[Serializable]
public class ObservationData
{
    public float[] position;
    public float[] velocity;
    public float[] rotation;
    public float[] radarData;
    public float health;
    public float ammo;
    public int stepCount;
    public bool done;
}

[Serializable]
public class ActionData
{
    public float throttle;
    public float steering;
    public bool fire;
}

public class RLAgent : MonoBehaviour
{
    [Header("References")]
    public SocketServer socketServer;

    [Header("RL Settings")]
    public float sendInterval = 0.1f;
    private float nextSendTime = 0f;

    [Header("Agent State")]
    public float throttle = 0f;
    public float steering = 0f;
    public bool fire = false;

    private ObservationData obs = new ObservationData();
    private int stepCount = 0;

    void Start()
    {
        if (socketServer == null)
            socketServer = FindObjectOfType<SocketServer>();
    }

    void FixedUpdate()
    {
        if (Time.time >= nextSendTime)
        {
            CollectObservation();
            SendObservation();
            nextSendTime = Time.time + sendInterval;
            stepCount++;
        }
    }

    private void CollectObservation()
    {
        obs.position = new float[] { transform.position.x, transform.position.y, transform.position.z };

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            obs.velocity = new float[] { rb.velocity.x, rb.velocity.y, rb.velocity.z };
        else
            obs.velocity = new float[] { 0, 0, 0 };

        obs.rotation = new float[] { transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z };
        obs.radarData = GetRadarData();
        obs.health = 100f;
        obs.ammo = 50f;
        obs.stepCount = stepCount;
        obs.done = false;
    }

    private float[] GetRadarData()
    {
        float[] radar = new float[8];
        float rayDistance = 100f;
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, rayDistance))
                radar[i] = hit.distance / rayDistance;
            else
                radar[i] = 1.0f;
        }
        return radar;
    }

    private void SendObservation()
    {
        string json = JsonUtility.ToJson(obs);
        if (socketServer != null)
            socketServer.SendObservation(json);
    }

    public void ApplyAction(ActionData action)
    {
        throttle = Mathf.Clamp01(action.throttle);
        steering = Mathf.Clamp(action.steering, -1f, 1f);
        fire = action.fire;
    }
}
