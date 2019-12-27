﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordnance : MonoBehaviour
{
    // Entity properties
    public float Lifetime = 10f;
    public float Damage = 0f;

    [HideInInspector]
    public GameObject owner;

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
        if (collision.gameObject != owner)
        {
            DoDamage(collision.gameObject);
        }
        else
        {
            Expire();
        }
    }

    void DoDamage(GameObject victim)
    {
        Health healthComponent = victim.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.AddHealth(-Damage);
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }

    void Expire()
    {
        Destroy(gameObject);
    }
}