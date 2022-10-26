using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Key : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;
    public GameObject LabDoor;
    public GameObject ChoresDoor;

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(2);
        UIHandler.GetComponent<Level1UI>().ShowSuccessPanel();
        gameObject.SetActive(false);
    }

    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close) 
        {
            if (MainManager.Instance.ChoresCompleted && MainManager.Instance.LabCompleted)
            {
                MainManager.Instance.ControlAllowed = false;

                if (MainManager.Instance.Level1TaskDone)
                {
                    UIHandler.GetComponent<Level1UI>().SetHelpText("Task:\nYou have the key! Go near the door and press Enter.");
                    MainManager.Instance.KeyCollected = true;
                    gameObject.GetComponent<Animator>().Play("CaptureKey");
                    StartCoroutine(Remove());
                }
                else
                {
                    UIHandler.GetComponent<Level1UI>().ShowTaskIntroPanel();
                }
            }
            else
            {
                MainManager.Instance.KeyAttempts += 1;
                if (MainManager.Instance.KeyAttempts == 2)
                {
                    LabDoor.gameObject.SetActive(true);
                    LabDoor.GetComponent<Animator>().Play("LabDoorPopUp");
                    ChoresDoor.gameObject.SetActive(true);
                    ChoresDoor.GetComponent<Animator>().Play("HousePopUp");
                    MainManager.Instance.ControlAllowed = false;
                    UIHandler.GetComponent<Level1UI>().ShowHintPanel();
                    UIHandler.GetComponent<Level1UI>().SetHelpText("Task:\nCheck the house and the door by pressing Enter near them.");
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
                MainManager.Instance.KeyPosition = transform.position;
                UIHandler.GetComponent<Level1UI>().Show("Key has jumped away! Try again.");
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
    
    void Start()
    {
        transform.position = MainManager.Instance.KeyPosition;
        if (MainManager.Instance.KeyAttempts >= 2)
        {
            LabDoor.gameObject.SetActive(true);
            LabDoor.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            ChoresDoor.gameObject.SetActive(true);
            ChoresDoor.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
