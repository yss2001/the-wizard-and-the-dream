using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChoresDoor : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.5f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;

    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            if (MainManager.Instance.PuddlesCleaned < 3)
            {
                MainManager.Instance.PuddlesCleaned = 0;
            }
            SceneManager.LoadScene(2);
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
