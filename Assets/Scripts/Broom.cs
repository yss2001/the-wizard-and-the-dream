using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    private Animator BroomAnimator;
    
    void SweepMove()
    {
        BroomAnimator.Play("Sweep");
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => SweepMove();
        BroomAnimator = gameObject.GetComponent<Animator>();
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
