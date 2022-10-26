using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChoresEntry : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 3.75f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;

    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            if (!MainManager.Instance.ChoresCompleted)
            {
                MainManager.Instance.ControlAllowed = false;
                SceneManager.LoadScene(4);
                //Debug.Log("Press Enter to enter Chores.\n");
            }
            else
            {
                UIHandler.GetComponent<Level1UI>().Show("You have finished Chores task!");
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
