using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        //GyroManager.Instance.EnableGyro();
        Input.gyro.enabled = true;
    }


    private void Update()
    {
        //Vector3 cameraRot = transform.eulerAngles;

        //cameraRot.y += (GyroManager.Instance.GetGyroRotation() * baseRotation).y;

        //transform.localRotation = Quaternion.Euler(cameraRot);

        // First try
        //transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;

        Quaternion referenceRot = Quaternion.identity;
        Quaternion deviceRot = DeviceRotation.Get();
        Quaternion eliminationOfXY = Quaternion.Inverse(
            Quaternion.FromToRotation(referenceRot * Vector3.up, deviceRot * Vector3.up)
        );

        Quaternion yRot = eliminationOfXY * deviceRot;
        float yaw = yRot.eulerAngles.y;

        Vector3 cameraRot = transform.eulerAngles;
        transform.localRotation = Quaternion.Euler(cameraRot.x, yaw, cameraRot.z);

        Debug.Log("yaw: " + yaw);

        
    }
}
