using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public Crosshair CrosshairPrefab;

    Crosshair crosshairInstance;

    void Start()
    {
        crosshairInstance = Instantiate(CrosshairPrefab);
    }

    void Update()
    {
        
    }
}
