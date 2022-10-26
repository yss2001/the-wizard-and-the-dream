using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LabEntry : MonoBehaviour
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
            if (!MainManager.Instance.LabCompleted)
            {
                MainManager.Instance.ControlAllowed = false;
                SceneManager.LoadScene(3);
                //Debug.Log("Press Enter to enter Lab.\n");
            }
            else
            {
                UIHandler.GetComponent<Level1UI>().Show("You have finished lab task!");
            }
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