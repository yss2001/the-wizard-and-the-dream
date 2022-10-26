using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1TaskIntro : MonoBehaviour
{
    public Button TaskButton;
    public GameObject BW;
    //private PlayerInput Input;
    //private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;

    void ButtonAction()
    {
        UIHandler.GetComponent<Level1UI>().ShowTaskPanel();
        gameObject.SetActive(false);
    }

    void Awake()
    {
        //Input = new PlayerInput();
        TaskButton.onClick.AddListener(ButtonAction);
    }
    private void OnEnable()
    {
        //Ground.Enable();
    }
    private void OnDisable()
    {
        //Ground.Disable();
    }
}
