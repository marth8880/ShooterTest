using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Entity properties
    public GameObject FirePoint;
    public Ordnance OrdnanceType;
    public float ShotDelay = 0.2f;

    [HideInInspector]
    public GameObject owner;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire(GameObject owner)
    {
        Ordnance ordnanceInstance = Instantiate(OrdnanceType, FirePoint.transform.position, FirePoint.transform.rotation);
        ordnanceInstance.owner = owner;
    }
}
