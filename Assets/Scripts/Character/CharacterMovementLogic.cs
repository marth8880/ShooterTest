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
    Collider coll;

    // Internal values
    bool grounded = false;
    float distToGround = 0f;
    const float distToGroundOffset = 0.1f;

    GameObject gameStateControllerObject;
    GameStateController gameStateController;
    
    void Start()
    {
        gameStateControllerObject = GameObject.FindGameObjectWithTag("GameStateController");
        gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

        rb = gameObject.GetComponent<Rigidbody>();
        coll = gameObject.GetComponent<Collider>();

        distToGround = coll.bounds.extents.y + distToGroundOffset;
    }

    void FixedUpdate()
    {
        if (!gameStateController.isDebugMode && gameStateController.CurrentGameState == GameStateController.GameState.Gameplay)
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Character is grounded");
            //grounded = true;
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

        if (coll.Raycast(ray, out hit, distToGround))
        {
            Debug.Log("Jump");
            Debug.Log("Character is not grounded");
            grounded = false;
            rb.AddRelativeForce(new Vector3(0, JumpForce * rb.drag, 0));
        }
    }
}
