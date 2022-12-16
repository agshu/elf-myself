using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class TakeOwnershipOnStart : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private int connected = 0;
    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
    }
        

    // Update is called once per frame
    void Update()
    {
        if (connected == 0 && Application.platform == RuntimePlatform.WindowsEditor) {
            realtimeTransform.RequestOwnership();
            connected = 1;
        } else if (connected == 0 && Application.platform == RuntimePlatform.WindowsPlayer) {
            realtimeTransform.RequestOwnership();
            connected = 1;
        }
    }
}
