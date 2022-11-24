using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 8f;

    // Update is called once per frame
    void Update()
    {
        Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity; // Movement in X to rotate around Y
        Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity; // - so that the upward motion rotates upwards
        
        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;
    }
}
