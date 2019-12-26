using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordnance : MonoBehaviour
{
    // Entity properties
    public float Lifetime = 10f;

    // Component refs
    Rigidbody rb;

    // Internal values
    float curLifetime = 0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, 100));
    }

    void Update()
    {
        curLifetime += Time.deltaTime;

        if (curLifetime > Lifetime)
        {
            Expire();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Expire();
    }

    void Expire()
    {
        Destroy(gameObject);
    }
}
