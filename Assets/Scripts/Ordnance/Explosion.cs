using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Entity properties
    public ParticleSystem ParticleEffect;
    public Collider Trigger;
    public float Damage = 0f;
    public float Lifetime = .1f;

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

        startExpire = true;
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

    void OnTriggerEnter(Collider other)
    {
        DoDamage(other.gameObject);
    }

    void DoDamage(GameObject victim)
    {
        Debug.Log("Explosion: DoDamage");
        Health healthComponent = victim.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.AddHealth(-Damage);
        }


    }

    void Expire()
    {
        Destroy(gameObject);
    }
}
