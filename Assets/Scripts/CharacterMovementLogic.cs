﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementLogic : MonoBehaviour
{
    public float MovementSpeed = 10.0f;
    public float JumpForce = 100.0f;

    Rigidbody rb;

    bool grounded = false;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("MoveForward") && grounded == true)
        {
            Move(new Vector3(0, 0, MovementSpeed));
        }

        if (Input.GetButton("MoveBackward") && grounded == true)
        {
            Move(new Vector3(0, 0, -MovementSpeed));
        }

        if (Input.GetButton("MoveLeft") && grounded == true)
        {
            Move(new Vector3(-MovementSpeed, 0, 0));
        }

        if (Input.GetButton("MoveRight") && grounded == true)
        {
            Move(new Vector3(MovementSpeed, 0, 0));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump") && grounded == true)
        {
            Jump();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }

    void Jump()
    {
        grounded = false;
        rb.AddForce(new Vector3(0, JumpForce, 0));
    }
}
