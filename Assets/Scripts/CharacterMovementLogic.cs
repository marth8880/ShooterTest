using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementLogic : MonoBehaviour
{
    public float MovementSpeed = 10.0f;
    public float JumpForce = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(new Vector3(0, 0, MovementSpeed));
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(new Vector3(0, 0, -MovementSpeed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-MovementSpeed, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(MovementSpeed, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, JumpForce));
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}
