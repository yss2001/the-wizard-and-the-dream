using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;

    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            UIHandler.GetComponent<Level0UI>().Introduction();
        }
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => Interacted();
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
