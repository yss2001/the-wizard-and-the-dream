using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;
    public GameObject ChoicePanel;
    public GameObject TaskPanel;

    void Interacted()
    {
        if (ChoicePanel.gameObject.activeSelf || TaskPanel.gameObject.activeSelf)
        {
            return;
        }
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            string name = gameObject.name;
            if (name == "Obstacle2" && MainManager.Instance.Obstacle2Choice != "")
            {
                return;
            }
            int obstacle = name[name.Length-1] - '0';
            MainManager.Instance.ControlAllowed = false;
            UIHandler.GetComponent<Level2UI>().ShowTaskPanel(obstacle);
            if (obstacle == 1)
            {
                UIHandler.GetComponent<Level2UI>().SetHelpText("Task:\nCrack the code to open the door.");
            }
            else if (obstacle == 2)
            {
                UIHandler.GetComponent<Level2UI>().SetHelpText("Task:\nPush the boulder away by going near it.");
            }
            else
            {
                UIHandler.GetComponent<Level2UI>().SetHelpText("Task:\nMatch the components to their correct location to repair the faulty door.");
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
