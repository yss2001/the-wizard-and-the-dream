using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level2Task1 : MonoBehaviour
{
    string Answer = "GENTLE";
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Verdict;
    public TMP_InputField Input;
    public GameObject Obstacle;
    public GameObject UIHandler;
    public Button CheckButton;
    public Button HelpButton;
    public Animator DoorAnimator;
    void OnEnable()
    {
        CheckButton.onClick.AddListener(Check);
        HelpButton.onClick.AddListener(Help);
        CheckButton.gameObject.SetActive(MainManager.Instance.Obstacle1Choice != "");
        HelpButton.gameObject.SetActive(MainManager.Instance.Obstacle1Choice == "");
        Verdict.text = "";
        Input.text = "";
        if (MainManager.Instance.Obstacle1Choice == "")
        {
            Description.text = "The jumbled code for this magical door is EBKQIB. Enter the correct code to unlock.";
        }
        else 
        {
            Description.text = $"The jumbled code for the door is EBKQIB. {MainManager.Instance.Avatars[MainManager.Instance.Obstacle1Choice]} has given you a hint: Change every alphabet to the one 2 places before. For example, change Z into W.";
        }
    }

    IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(2);
        Obstacle.gameObject.SetActive(false);
    }
    public void Check()
    {
        if (!MainManager.Instance.Obstacle1Done)
        {
            if (Input.text.ToUpper() == Answer && MainManager.Instance.Obstacle1Choice != "")
            {
                Verdict.text = "Yes! The door has opened!";
                MainManager.Instance.Obstacle1Done = true;
                DoorAnimator.Play("MoveDown");
                StartCoroutine(CloseCoroutine());
            }
            else
            {
                Verdict.text = "Sorry, try again!";
            }
        }
    }
    public void Help()
    {
        if (!MainManager.Instance.Obstacle1Done)
        {
            UIHandler.GetComponent<Level2UI>().ShowChoicePanel(1);
            gameObject.SetActive(false);
        }
    }
}
