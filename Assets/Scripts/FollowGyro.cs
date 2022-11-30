using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    private Quaternion startRotation;

    private void Start()
    {
        //GyroManager.Instance.EnableGyro();

        Input.gyro.enabled = true;
        startRotation = transform.rotation;

    }


    private void Update()
    {
        //Vector3 cameraRot = transform.eulerAngles;

        //cameraRot.y = (GyroManager.Instance.GetGyroRotation() * baseRotation).y;

        //transform.localRotation = Quaternion.Euler(cameraRot);

        // First try
        //transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;

        //// Get device rotation, eliminate rotation around x and z axes
        Quaternion referenceRot = Quaternion.identity;
        Quaternion deviceRot = DeviceRotation.Get();
        Quaternion eliminationOfXZ = Quaternion.Inverse(
            Quaternion.FromToRotation(referenceRot * Vector3.up, deviceRot * Vector3.up)
        );

        // Yaw rotation
        Quaternion yRot = eliminationOfXZ * deviceRot;
        float yaw = yRot.eulerAngles.y;
        float cameraRotY = transform.localRotation.eulerAngles.y;
        Debug.Log("yaw: " + yaw + "; camera y rot: " + cameraRotY);

        // Transform cameras rotation to that of phone, with offset since Unity have left handed coordinates whilst the phone is right handed?
        Vector3 cameraRot = transform.eulerAngles;
        transform.localRotation = Quaternion.Euler(cameraRot.x, (yaw), cameraRot.z);


        
    }
}
