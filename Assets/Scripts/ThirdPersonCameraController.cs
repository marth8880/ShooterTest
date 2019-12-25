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

    // Tweak values
    const float lookYawSpeedMultiplierBase = 50f;
    const float lookPitchSpeedMultiplierBase = 50f;

    // Internal values
    int invertPitchSwitch = -1;
    float lookYaw = 0f;
    float lookPitch = 0f;
    
    void Start()
    {
        if (InvertPitch)
        {
            invertPitchSwitch = 1;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * LookYawSpeedMultiplier * lookYawSpeedMultiplierBase * Time.deltaTime);
        lookYaw += Input.GetAxis("Mouse X") * LookYawSpeedMultiplier * lookYawSpeedMultiplierBase * Time.deltaTime;

        lookPitch += Input.GetAxis("Mouse Y") * LookPitchSpeedMultiplier * lookPitchSpeedMultiplierBase * invertPitchSwitch * Time.deltaTime;
        lookPitch = Mathf.Clamp(lookPitch, LookPitchMinimumDegrees, LookPitchMaximumDegrees);

        CameraRig.transform.eulerAngles = new Vector3(lookPitch, lookYaw, 0f);
    }
}
