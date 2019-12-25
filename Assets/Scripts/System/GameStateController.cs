using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState;
    public bool isDebugMode = false;

    public enum GameState
    {
        Gameplay,
        Interface
    }

    void Start()
    {
        ChangeGameState(GameState.Gameplay);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (isDebugMode)
            {
                ExitDebugMode();
            }
            else
            {
                EnterDebugMode();
            }
        }
    }

    public void ChangeGameState(GameState newState)
    {
        CurrentGameState = newState;

        switch (newState)
        {
            case GameState.Gameplay:
                Debug.Log("Game state changed: Gameplay");

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.Interface:
                Debug.Log("Game state changed: Interface");

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
    }

    void EnterDebugMode()
    {
        Debug.Log("Entering debug mode");

        isDebugMode = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ExitDebugMode()
    {
        Debug.Log("Exiting debug mode");

        isDebugMode = false;

        switch (CurrentGameState)
        {
            case GameState.Gameplay:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.Interface:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
    }
}
