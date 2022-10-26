using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public GameObject UIHandler;

    public void Answer()
    {
        string name = gameObject.name;
        if (name[1] == '1')
        {
            MainManager.Instance.Question1Done = true;
            UIHandler.GetComponent<Level3UI>().HideQuestion(1);
            UIHandler.GetComponent<Level3UI>().ShowVerdict(1, name);
        }
        else if (name[1] == '2')
        {
            MainManager.Instance.Question2Done = true;
            UIHandler.GetComponent<Level3UI>().HideQuestion(2);
            UIHandler.GetComponent<Level3UI>().ShowVerdict(2, name);
        }
        else
        {
            MainManager.Instance.Question3Done = true;
            UIHandler.GetComponent<Level3UI>().HideQuestion(3);
            UIHandler.GetComponent<Level3UI>().ShowVerdict(3, name);
        }
    }
}
