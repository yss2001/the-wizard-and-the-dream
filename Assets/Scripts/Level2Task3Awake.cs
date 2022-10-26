using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level2Task3Awake : MonoBehaviour
{
    public TextMeshProUGUI Description;
    public Button HelpButton;
    public GameObject UIHandler;
    public Button CheckButton;
    public TextMeshProUGUI Verdict;
    public GameObject Obstacle;
    public GameObject RedWire;
    public GameObject GreenWire;
    public GameObject BlueWire;
    public GameObject MaroonChip;
    public GameObject BlueChip;
    public GameObject PurpleChip;
    public Animator DoorAnimator;
    
    void OnEnable()
    {
        RedWire.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        BlueWire.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        GreenWire.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        MaroonChip.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        BlueChip.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        PurpleChip.gameObject.SetActive(MainManager.Instance.Obstacle3Choice != "");
        Verdict.text = "";
        HelpButton.onClick.AddListener(Help);
        CheckButton.onClick.AddListener(Check);
        HelpButton.gameObject.SetActive(MainManager.Instance.Obstacle3Choice == "");
        if (MainManager.Instance.Obstacle3Choice == "")
        {
            Description.text = "This electric door is not opening due to missing components! ";
        }
        else
        {
            Description.text = $"{MainManager.Instance.Avatars[MainManager.Instance.Obstacle3Choice]} has given you the parts. Place them in the right slot!";
        }
    }
    
    void Help()
    {
        UIHandler.GetComponent<Level2UI>().ShowChoicePanel(3);
        gameObject.SetActive(false);
    }

    IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(2);
        Obstacle.gameObject.SetActive(false);
    }

    void Check()
    {
        foreach(KeyValuePair<string, bool> Component in MainManager.Instance.Obstacle3Components)
        {
            if (Component.Value == false)
            {
                Verdict.text = "That didn't work.";
                return;
            }
        }
        Verdict.text = "The door has opened!";
        MainManager.Instance.Obstacle3Done = true;
        DoorAnimator.Play("MoveDown");
        StartCoroutine(CloseCoroutine());
    }
}
