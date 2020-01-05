using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Entity references
    public Crosshair CrosshairPrefab;
    GameObject gameControllerObject;
    GameStateController gameStateController;

    Crosshair crosshairInstance;

    void Start()
    {
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameStateController = gameControllerObject.GetComponent<GameStateController>();

        crosshairInstance = Instantiate(CrosshairPrefab);

        GameStateController.onGameStateChange += OnGameStateChange;
    }

    void Update()
    {
        
    }

    void OnGameStateChange(GameStateController.GameState gameState)
    {
        Debug.Log("HUDController: OnGameStateChange = " + gameState.ToString());
    }
}
