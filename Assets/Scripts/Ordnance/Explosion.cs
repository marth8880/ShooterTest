using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Entity properties
    public GameObject ParticleEffect;
    public float Damage = 0f;
    public float Lifetime = .1f;
    public float Radius = 5f;
    public bool AffectOwner = false;

    [HideInInspector]
    public GameObject owner;

    // Component refs

    // Internal values
    float curLifetime = 0f;
    bool startExpire = false;

    void Start()
    {
        if (ParticleEffect != null)
        {
            Instantiate(ParticleEffect, transform.position, transform.rotation);
        }

        DoDamage();
    }

    void Update()
    {
        if (Lifetime > 0 && startExpire)
        {
            curLifetime += Time.deltaTime;
            if (curLifetime >= Lifetime)
            {
                Expire();
            }
        }
    }

    void DoDamage()
    {
        Debug.Log("Explosion: DoDamage");

        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, Radius);
        foreach (Collider collider in objectsInRange)
        {
            Health healthComponent = collider.GetComponent<Health>();
            if (healthComponent != null)
            {
                // Don't affect the owner unless specified
                if (collider.gameObject != owner.gameObject)
                {
                    healthComponent.AddHealth(-Damage);
                }
                else
                {
                    if (AffectOwner)
                    {
                        healthComponent.AddHealth(-Damage);
                    }
                }
            }
        }

        startExpire = true;
    }

    void Expire()
    {
        Destroy(gameObject);
    }
}
