using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Entity properties
    public float LookYawSpeedMultiplier = 1.0f;

    void Start()
    {
        camera = gameObject.GetComponentInChildren<Camera>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * LookYawSpeedMultiplier);
    }
}
