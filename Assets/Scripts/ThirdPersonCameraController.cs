using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Entity properties
    public float LookYawSpeedMultiplier = 1.0f;
    public float LookPitchSpeedMultiplier = 1.0f;
    public float LookPitchMinimumDegrees = -90f;
    public float LookPitchMaximumDegrees = 90f;
    public bool InvertPitch = false;
    public GameObject CameraRig;

    float lookPitchMin = 0f;
    float lookPitchMax = 0f;
    int invertPitchSwitch = -1;
    
    void Start()
    {
        lookPitchMin = LookPitchMinimumDegrees / 360;
        lookPitchMax = LookPitchMaximumDegrees / 360;

        if (InvertPitch)
        {
            invertPitchSwitch = 1;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * LookYawSpeedMultiplier);
        Debug.Log("CameraRig.transform.rotation.x = " + CameraRig.transform.localRotation.x);
        if (CameraRig.transform.localRotation.x > lookPitchMin && CameraRig.transform.localRotation.x < lookPitchMax)
        {
            CameraRig.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * LookPitchSpeedMultiplier * invertPitchSwitch);
        }
    }
}
