using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementLogic : MonoBehaviour
{
    // Entity properties
    public float MovementSpeed = 10.0f;
    public float JumpForce = 100.0f;

    // Tweak values

    // Component refs
    Rigidbody rb;

    // Internal values
    bool grounded = false;

    GameObject gameStateControllerObject;
    GameStateController gameStateController;
    
    void Start()
    {
        gameStateControllerObject = GameObject.FindGameObjectWithTag("GameStateController");
        gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!gameStateController.isDebugMode)
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

            if (Input.GetButton("Jump") && grounded == true)
            {
                Jump();
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    void Move(Vector3 direction)
    {
        rb.AddRelativeForce(direction);
    }

    void Jump()
    {
        grounded = false;
        rb.AddForce(new Vector3(0, JumpForce * rb.drag, 0));
    }
}
