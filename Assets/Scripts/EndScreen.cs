using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Button Quit;

    void Start()
    {
        Quit.onClick.AddListener(QuitGame);
        Text.text = "Congratulations " + MainManager.Instance.PlayerName + Text.text;
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
