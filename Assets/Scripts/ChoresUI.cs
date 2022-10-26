using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChoresUI : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HelpPanel;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI PuddlesCleaned;
    public TextMeshProUGUI SuccessText;
    public GameObject BW;

    void Help()
    {
        if (MainManager.Instance.ControlAllowed)
        {
            MainManager.Instance.ControlAllowed = false;
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            HelpPanel.gameObject.SetActive(true);
        }
    }
    public void Show(string Text)
    {
        if (Info.gameObject.activeSelf)
            Info.gameObject.SetActive(false);
        Info.text = Text;
        Info.gameObject.SetActive(true);
    }
    public void UpdatePuddlesCleaned()
    {
        PuddlesCleaned.text = $"Puddles Cleaned: {MainManager.Instance.PuddlesCleaned} / 3";
    }
    public void ShowPanel()
    {
        /*if (MainManager.Instance.LabCompleted)
        {
            SuccessText.text += " Since you have already helped Marie Curie, you should now be able to collect the key. Good Luck!";
        }
        else
        {
            SuccessText.text += " Your mother has made catching the key a bit easier, but you still have to finish the task in the other door. Good Luck!";
        }*/
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        Panel.gameObject.SetActive(true);
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Help.performed += context => Help();
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
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
