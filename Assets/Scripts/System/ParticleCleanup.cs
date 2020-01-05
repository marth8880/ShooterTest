using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleCleanup : MonoBehaviour
{
    // Entity properties
    public GameObject[] ParticleSystems;

    // Internal values
    List<float> durations = new List<float>();
    float particleLifetime = 0f;
    float curLifetime = 0f;

    void Start()
    {
        foreach (GameObject particle in ParticleSystems)
        {
            ParticleSystem pfxComponent = particle.GetComponent<ParticleSystem>();
            durations.Add(pfxComponent.main.startLifetime.constantMax * pfxComponent.main.startLifetimeMultiplier);
        }

        particleLifetime = durations.Max();
    }

    void Update()
    {
        curLifetime += Time.deltaTime;
        if (curLifetime >= particleLifetime)
        {
            Destroy(gameObject);
        }
    }
}
