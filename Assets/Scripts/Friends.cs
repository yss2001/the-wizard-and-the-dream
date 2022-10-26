using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friends : MonoBehaviour
{
    public GameObject CrateMover;
    public Transform Plate2Position;
    public Transform Plate3Position;
    public Button NoButton;
    public Button HelpButton;

    void FriendsHelp()
    {
        if (!MainManager.Instance.Question2Done && Plate2Position.transform.position.z == 0)
        {
            CrateMover.GetComponent<CrateMover>().moveBig2 = true;
            CrateMover.GetComponent<CrateMover>().moveMed2 = true;
        }
        else if (MainManager.Instance.Question2Done && !MainManager.Instance.Question3Done && Plate3Position.transform.position.z == 0)
        {
            CrateMover.GetComponent<CrateMover>().moveBig3 = true;
            CrateMover.GetComponent<CrateMover>().moveMed3 = true;
        }
        NoButton.GetComponent<CloseButton>().Close();
    }

    void Awake()
    {
        HelpButton.onClick.AddListener(FriendsHelp);
    }
}
