using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class TakeOwnershipOnStart : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();

    }
        

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
            realtimeTransform.RequestOwnership();
        }
    }
}
