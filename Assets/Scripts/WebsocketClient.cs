using System;
using System.Collections.Concurrent;
using UnityEngine;
using WebSocketSharp;

public class WebsocketClient : MonoBehaviour
{
    public float rotSpeed = 10f;
    public int maxRot = 60;
    public int minRot = 60;

    WebSocket ws;
    ConcurrentQueue<string> incoming_messages = new ConcurrentQueue<string>();

    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://elfmyselfvr.herokuapp.com/");

        ws.Connect();

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Connection open");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message received from " + ((WebSocket)sender).Url + ", Data: " + e.Data);
            incoming_messages.Enqueue(e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("Error: " + e);
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (incoming_messages.TryDequeue(out var message))
        {
            HandleMessage(message);
        }
    }

    private void HandleMessage(string message)
    {
        Vector3 cameraRot = transform.eulerAngles;

        if (message == "right")
        {
            cameraRot.y += rotSpeed * Time.deltaTime;
        }
        else if(message == "left") 
        {
            cameraRot.y -= rotSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(cameraRot);

        Debug.Log("Message: " + message);
    }
}
