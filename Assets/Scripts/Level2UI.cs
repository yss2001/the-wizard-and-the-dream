using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2UI : MonoBehaviour
{
    public TextMeshProUGUI Info;
    public GameObject HelpPanel;
    public TextMeshProUGUI HelpText;
    public GameObject ObstacleChoicePanel1;
    public GameObject ObstacleChoicePanel2;
    public GameObject ObstacleChoicePanel3;
    public GameObject ObstacleTaskPanel1;
    public GameObject ObstacleTaskPanel2;
    public GameObject ObstacleTaskPanel3;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject BW;

    public void ShowChoicePanel(int obstacle)
    {
        if (obstacle == 1)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleChoicePanel1.gameObject.SetActive(true);
        }
        else if (obstacle == 2)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleChoicePanel2.gameObject.SetActive(true);
        }
        else
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleChoicePanel3.gameObject.SetActive(true);
        }
    }
    public void HideChoicePanel(int obstacle)
    {
        if (obstacle == 1)
        {
            ObstacleChoicePanel1.gameObject.SetActive(false);
        }
        else if (obstacle == 2)
        {
            ObstacleChoicePanel2.gameObject.SetActive(false);
        }
        else
        {
            ObstacleChoicePanel3.gameObject.SetActive(false);
        }
    }

    public void ShowTaskPanel(int obstacle)
    {
        if (obstacle == 1)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleTaskPanel1.gameObject.SetActive(true);
        }
        else if (obstacle == 2)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleTaskPanel2.gameObject.SetActive(true);
        }
        else
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            ObstacleTaskPanel3.gameObject.SetActive(true);
        }
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Help.performed += context => Help();
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
    }
    void Help()
    {
        if (MainManager.Instance.ControlAllowed)
        {
            MainManager.Instance.ControlAllowed = false;
            HelpPanel.gameObject.SetActive(true);
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        }
    }
    public void SetHelpText(string Text)
    {
        HelpText.text = Text;
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
