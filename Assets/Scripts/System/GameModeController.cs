using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    // Entity properties
    public GameObject PlayerPrefab;
    public GameObject PlayerSpawnPoint;

    GameObject playerCharacter;

    void Start()
    {
        playerCharacter = Instantiate(PlayerPrefab, PlayerSpawnPoint.transform.position, PlayerSpawnPoint.transform.rotation);
    }
}
