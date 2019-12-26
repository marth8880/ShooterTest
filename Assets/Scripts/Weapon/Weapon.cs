using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Entity properties
    public GameObject FirePoint;
    public Ordnance OrdnanceType;
    public float ShotDelay = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire()
    {
        Ordnance ordnanceInstance = Instantiate(OrdnanceType, FirePoint.transform.position, FirePoint.transform.rotation);
    }
}
