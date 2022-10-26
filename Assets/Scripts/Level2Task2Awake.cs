using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level2Task2Awake : MonoBehaviour
{
    public TextMeshProUGUI Description;
    public Button HelpButton;
    public GameObject UIHandler;

    void OnEnable()
    {
        HelpButton.onClick.AddListener(Help);
        HelpButton.gameObject.SetActive(MainManager.Instance.Obstacle2Choice == "");
        if (MainManager.Instance.Obstacle2Choice == "")
        {
            if (!MainManager.Instance.CanPushRock)
            {
                Description.text = "This heavy boulder looks like it is very hard to push away.";
            }
            else
            {
                Description.text = "Simply go towards the rock and it will get pushed. But if you do it without help    , it will move slowly!";
            }
        }
        else
        {
            Description.text = $"{MainManager.Instance.Avatars[MainManager.Instance.Obstacle2Choice]} has given you the strength to push the rock faster! Simply go towards the rock and it will get pushed.";
        }
    }

    void Help()
    {
        UIHandler.GetComponent<Level2UI>().ShowChoicePanel(2);
        gameObject.SetActive(false);
    }

}
