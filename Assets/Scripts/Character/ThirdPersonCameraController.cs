using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    // Entity properties
    public float LookYawSpeedMultiplier = 1.0f;
    public float LookPitchSpeedMultiplier = 1.0f;
    public float LookPitchMinimumDegrees = -90f;
    public float LookPitchMaximumDegrees = 90f;
    public bool InvertPitch = false;
    public GameObject CameraObject;
    public GameObject CameraRig;
    public GameObject WeaponAttachPoint;
    public float AimFieldOfView = 90f;
    public float ZoomFieldOfView = 30f;
    public float ZoomSpeedMultiplier = 2f;

    // Entity references
    GameObject gameStateControllerObject;
    GameStateController gameStateController;
    Camera cam;

    // Tweak values
    const float lookYawSpeedMultiplierBase = 50f;
    const float lookPitchSpeedMultiplierBase = 50f;

    // Internal values
    int invertPitchSwitch = -1;
    float lookYaw = 0f;
    float lookPitch = 0f;
    float curZoomTime = 0f;

    void Start()
    {
        gameStateControllerObject = GameObject.FindGameObjectWithTag("GameStateController");
        gameStateController = gameStateControllerObject.GetComponent<GameStateController>();

        cam = CameraObject.GetComponent<Camera>();

        if (InvertPitch)
        {
            invertPitchSwitch = 1;
        }
    }

    void Update()
    {
        if (!gameStateController.isDebugMode && gameStateController.CurrentGameState == GameStateController.GameState.Gameplay)
        {
            // Rotate the character object
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * LookYawSpeedMultiplier * lookYawSpeedMultiplierBase * Time.deltaTime);
            // Rotate the camera arm
            lookYaw += Input.GetAxis("Mouse X") * LookYawSpeedMultiplier * lookYawSpeedMultiplierBase * Time.deltaTime;

            lookPitch += Input.GetAxis("Mouse Y") * LookPitchSpeedMultiplier * lookPitchSpeedMultiplierBase * invertPitchSwitch * Time.deltaTime;
            lookPitch = Mathf.Clamp(lookPitch, LookPitchMinimumDegrees, LookPitchMaximumDegrees);

            WeaponAttachPoint.transform.eulerAngles = new Vector3(lookPitch, WeaponAttachPoint.transform.eulerAngles.y, 0f);
            CameraRig.transform.eulerAngles = new Vector3(lookPitch, lookYaw, 0f);

            if (Input.GetButton("AimWeapon"))
            {
                cam.fieldOfView = Mathf.Lerp(AimFieldOfView, ZoomFieldOfView, curZoomTime);
                if (curZoomTime <= 1)
                {
                    curZoomTime += Time.deltaTime * ZoomSpeedMultiplier;
                }
            }
            else
            {
                cam.fieldOfView = Mathf.Lerp(AimFieldOfView, ZoomFieldOfView, curZoomTime);
                if (curZoomTime >= 0)
                {
                    curZoomTime -= Time.deltaTime * ZoomSpeedMultiplier;
                }
            }
            Debug.Log("curZoomTime = " + curZoomTime);
        }
    }
}
