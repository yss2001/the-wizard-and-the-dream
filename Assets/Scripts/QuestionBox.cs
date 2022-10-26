using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBox : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;
    public GameObject NextPlate;
    int box;

    void Interacted()
    {
        if ((box == 1 && MainManager.Instance.Question1Done) || (box == 2 && MainManager.Instance.Question2Done) || (box == 3 && MainManager.Instance.Question3Done))
        {
            return;
        }
        else
        {
            Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
            if (Close)
            {
                MainManager.Instance.ControlAllowed = false;
                UIHandler.GetComponent<Level3UI>().ShowQuestion(box);
            }
        }
    }

    void Update()
    {
        if ((box == 1 && !MainManager.Instance.Question1Done) || (box == 2 && !MainManager.Instance.Question2Done) || (box == 3 && !MainManager.Instance.Question3Done))
        {
            transform.Rotate(0, 25 * Time.deltaTime, 0);
        }
    }

    void Awake()
    {
        box = gameObject.name[gameObject.name.Length-1]-'0';
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
