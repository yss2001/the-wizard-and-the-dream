using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1UI : MonoBehaviour
{
    public TextMeshProUGUI Info;
    public GameObject SuccessPanel;
    public GameObject HintPanel;
    public GameObject IntroPanel;
    public GameObject HelpPanel;
    public GameObject TaskIntroPanel;
    public GameObject TaskPanel;
    public TextMeshProUGUI HelpText;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public TextMeshProUGUI IntroText;
    public GameObject BW;

    public void Show(string Text)
    {
        if (Info.gameObject.activeSelf)
            Info.gameObject.SetActive(false);
        Info.text = Text;
        Info.gameObject.SetActive(true);
    }

    public void ShowTaskPanel()
    {
        TaskPanel.gameObject.SetActive(true);
    }

    public void ShowTaskIntroPanel()
    {
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        TaskIntroPanel.gameObject.SetActive(true);
    }

    public void ShowSuccessPanel()
    {
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        SuccessPanel.gameObject.SetActive(true);
    }

    public void ShowHintPanel()
    {
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        HintPanel.gameObject.SetActive(true);
    }

    void Help()
    {
        if (MainManager.Instance.ControlAllowed)
        {
            MainManager.Instance.ControlAllowed = false;
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            HelpPanel.gameObject.SetActive(true);
        }
    }

    public void SetHelpText(string Text)
    {
        HelpText.text = Text;
    }

    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Help.performed += context => Help();
        //IntroText.text = $"Hello {MainManager.Instance.PlayerName}, " + IntroText.text;
        if (!MainManager.Instance.Level1Visited)
        {     
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");  
        } 
    }

    void Start()
    {
        if (MainManager.Instance.Level1Visited)
        {
            IntroPanel.gameObject.SetActive(false);
        }
        if (MainManager.Instance.ChoresCompleted && MainManager.Instance.LabCompleted) {
            SetHelpText("Task:\nThe key won't jump now - try getting it now!");
        }
        else if (MainManager.Instance.KeyAttempts >= 2) {
            SetHelpText("Task:\nCheck the house and the door by pressing Enter near them.");
        }
        MainManager.Instance.Level1Visited = true;
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