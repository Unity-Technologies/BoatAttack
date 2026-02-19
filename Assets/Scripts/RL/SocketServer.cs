using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class SocketServer : MonoBehaviour
{
    [Header("Socket Settings")]
    public int port = 9876;
    public bool autoStart = true;

    private TcpListener server;
    private TcpClient client;
    private NetworkStream stream;
    private Thread serverThread;
    private bool isRunning = false;

    private Queue<string> logQueue = new Queue<string>();
    private Queue<string> errorQueue = new Queue<string>();
    private object lockObj = new object();

    private Queue<string> messageQueue = new Queue<string>();

    void Start()
    {
        if (autoStart)
            StartServer();
    }

    void Update()
    {
        lock (lockObj)
        {
            while (logQueue.Count > 0)
                Debug.Log(logQueue.Dequeue());
            while (errorQueue.Count > 0)
                Debug.LogError(errorQueue.Dequeue());
        }

        lock (lockObj)
        {
            while (messageQueue.Count > 0)
                ProcessMessage(messageQueue.Dequeue());
        }
    }

    public void StartServer()
    {
        serverThread = new Thread(new ThreadStart(ListenForClients));
        serverThread.IsBackground = true;
        serverThread.Start();
        EnqueueLog($"[SocketServer] Started on port {port}");
    }

    private void ListenForClients()
    {
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            isRunning = true;
            EnqueueLog("[SocketServer] Waiting for Python client...");
            client = server.AcceptTcpClient();
            stream = client.GetStream();
            EnqueueLog("[SocketServer] Python client connected!");

            while (isRunning)
            {
                if (stream != null && stream.DataAvailable)
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    lock (lockObj)
                    {
                        messageQueue.Enqueue(message);
                    }
                }
                Thread.Sleep(10);
            }
        }
        catch (SocketException e)
        {
            EnqueueError($"[SocketServer] Socket Error: {e.Message}");
        }
        catch (Exception e)
        {
            EnqueueError($"[SocketServer] Error: {e.Message}");
        }
    }

    private void ProcessMessage(string message)
    {
        Debug.Log($"[SocketServer] Received: {message}");
        try
        {
            ActionData action = JsonUtility.FromJson<ActionData>(message);
            if (action != null)
            {
                RLAgent[] agents = FindObjectsOfType<RLAgent>();
                foreach (var agent in agents)
                    agent.ApplyAction(action);
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"[SocketServer] Failed to parse action: {e.Message}");
        }
    }

    public void SendObservation(string jsonData)
    {
        if (stream != null && stream.CanWrite)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(jsonData + "\n");
                lock (lockObj)
                {
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }
            catch (Exception e)
            {
                EnqueueError($"[SocketServer] Send error: {e.Message}");
            }
        }
    }

    private void EnqueueLog(string message)
    {
        lock (lockObj) { logQueue.Enqueue(message); }
    }

    private void EnqueueError(string message)
    {
        lock (lockObj) { errorQueue.Enqueue(message); }
    }

    void OnApplicationQuit()
    {
        isRunning = false;
        if (stream != null) try { stream.Close(); } catch { }
        if (client != null) try { client.Close(); } catch { }
        if (server != null) try { server.Stop(); } catch { }
        if (serverThread != null && serverThread.IsAlive) serverThread.Join(1000);
        Debug.Log("[SocketServer] Stopped");
    }

    void OnDestroy() { OnApplicationQuit(); }
}
