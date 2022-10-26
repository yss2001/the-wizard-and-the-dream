using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    private PlayerMovement Movement;
    private PlayerLook Look;
    
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Movement = GetComponent<PlayerMovement>();
        Look = GetComponent<PlayerLook>();
        Ground.Jump.performed += context => Movement.Jump();
    }

    void FixedUpdate()
    {
        Movement.ProcessMove(Ground.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        Look.ProcessLook(Ground.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        Ground.Enable();
    }
    private void OnDisable()
    {
        Ground.Disable();
    }

}
