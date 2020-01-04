using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordnance : MonoBehaviour
{
    // Entity properties
    public float Lifetime = 10f;
    public float Damage = 0f;
    public float Velocity = 100f;
    public Explosion ExplosionPrefab;

    [HideInInspector]
    public GameObject owner;

    // Component refs
    Rigidbody rb;

    // Internal values
    float curLifetime = 0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, Velocity));
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
        }

        Explode();
    }

    void Explode()
    {
        if (ExplosionPrefab != null)
        {
            Explosion explosion = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            explosion.owner = owner;
        }
        Destroy(gameObject);
    }

    void Expire()
    {
        Destroy(gameObject);
    }
}
