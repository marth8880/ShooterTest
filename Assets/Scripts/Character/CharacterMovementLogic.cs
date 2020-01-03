using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementLogic : MonoBehaviour
{
    // Entity properties
    public float MovementSpeed = 10.0f;
    public float JumpForce = 100.0f;
    public float AirMovementSpeedMultiplier = .5f;

    // Tweak values

    // Component refs
    Rigidbody rb;
    Collider coll;

    // Internal values
    bool grounded = false;
    float distToGround = 0f;
    const float distToGroundOffset = 0.1f;
    float airMovementSpeed = 0f;

    GameObject gameStateControllerObject;
    GameStateController gameStateController;
    
    void Start()
    {
        gameStateControllerObject = GameObject.FindGameObjectWithTag("GameStateController");
        gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

        rb = gameObject.GetComponent<Rigidbody>();
        coll = gameObject.GetComponent<Collider>();

        distToGround = coll.bounds.extents.y + distToGroundOffset;
        airMovementSpeed = MovementSpeed * AirMovementSpeedMultiplier;
    }

    void FixedUpdate()
    {
        if (!gameStateController.isDebugMode && gameStateController.CurrentGameState == GameStateController.GameState.Gameplay)
        {
            if (Input.GetButton("MoveForward"))
            {
                if (grounded)
                    Move(new Vector3(0, 0, MovementSpeed));
                else
                    Move(new Vector3(0, 0, airMovementSpeed));
            }

            if (Input.GetButton("MoveBackward"))
            {
                if (grounded)
                    Move(new Vector3(0, 0, -MovementSpeed));
                else
                    Move(new Vector3(0, 0, -airMovementSpeed));
            }

            if (Input.GetButton("MoveLeft"))
            {
                if (grounded)
                    Move(new Vector3(-MovementSpeed, 0, 0));
                else
                    Move(new Vector3(-airMovementSpeed, 0, 0));
            }

            if (Input.GetButton("MoveRight"))
            {
                if (grounded)
                    Move(new Vector3(MovementSpeed, 0, 0));
                else
                    Move(new Vector3(airMovementSpeed, 0, 0));
            }

            if (Input.GetButtonDown("Jump") && grounded == true)
            {
                Jump();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Character is grounded");
        grounded = true;
    }


    void Move(Vector3 direction)
    {
        rb.AddRelativeForce(direction);
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distToGround))
        {
            grounded = false;
            
            rb.AddRelativeForce(new Vector3(0, JumpForce * rb.drag, 0));
        }
    }
}
