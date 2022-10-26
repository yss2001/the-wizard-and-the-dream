using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarButton : MonoBehaviour
{
    public GameObject UIHandler;

    public void Choose()
    {
        string name = gameObject.name;
        if (name[1] == '1')
        {
            MainManager.Instance.Obstacle1Choice = name;
            UIHandler.GetComponent<Level2UI>().ShowTaskPanel(1);
            UIHandler.GetComponent<Level2UI>().HideChoicePanel(1);
        }
        else if (name[1] == '2')
        {
            MainManager.Instance.CanPushRock = true;
            if (name != "O2Self")
            {
                MainManager.Instance.Obstacle2Choice = name;
            }
            UIHandler.GetComponent<Level2UI>().ShowTaskPanel(2);
            UIHandler.GetComponent<Level2UI>().HideChoicePanel(2);
        }
        else
        {
            MainManager.Instance.Obstacle3Choice = name;
            UIHandler.GetComponent<Level2UI>().ShowTaskPanel(3);
            UIHandler.GetComponent<Level2UI>().HideChoicePanel(3);
        }
    }
}
