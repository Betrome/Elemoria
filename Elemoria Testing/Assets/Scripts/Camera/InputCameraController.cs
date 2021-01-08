using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
 
public class InputCameraController : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 LookCamera; // your LookDelta
    public float deadZone = 0.1f;
 
    private void Awake()
    {
        controls = new PlayerControls();
 
        controls.Gameplay.MoveCamera.performed += ctx => LookCamera = ctx.ReadValue<Vector2>().normalized;
        controls.Gameplay.MoveCamera.canceled += ctx => LookCamera = Vector2.zero;
        controls.Gameplay.MoveCamera.performed += ctx => GetInput();
    }
 
    private void GetInput()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }
 
    public float GetAxisCustom(string axisName)
    {
        LookCamera.Normalize();
 
        if (axisName == "Cam X")
        {
          if (LookCamera.x > deadZone || LookCamera.x < -deadZone) // To stabilise Cam and prevent it from rotating when LookCamera.x value is between deadZoneX and - deadZoneX
           {
             return LookCamera.x;
           }
        }
 
        else if (axisName == "Cam Y")
        {
            if (LookCamera.y > deadZone || LookCamera.y < -deadZone) // To stabilise Cam and prevent it from rotating when LookCamera.x value is between deadZoneX and - deadZoneX
           {
                return LookCamera.y;
           }
        }
 
        return 0;
    }
 
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
 
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}