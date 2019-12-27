using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Entity properties
    public GameObject WeaponAttachPoint;

    // Entity references
    GameObject gameStateControllerObject;
    GameStateController gameStateController;

    // Internal values
    public Weapon equippedWeapon;

    Weapon weaponInstance;

    void Start()
    {
        gameStateControllerObject = GameObject.FindGameObjectWithTag("GameStateController");
        gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

        weaponInstance = Instantiate(equippedWeapon);
        weaponInstance.transform.parent = WeaponAttachPoint.transform;
        weaponInstance.transform.localPosition = Vector3.zero;
        weaponInstance.transform.localRotation = new Quaternion();
    }

    void Update()
    {
        if (!gameStateController.isDebugMode && gameStateController.CurrentGameState == GameStateController.GameState.Gameplay)
        {
            if (Input.GetButtonDown("FireWeapon"))
            {
                if (weaponInstance != null)
                {
                    weaponInstance.Fire(gameObject);
                }
            }
        }
    }
}
