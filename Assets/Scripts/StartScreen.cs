using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public Button Play;
    public Button Quit;
    public TMP_InputField Name;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject Panel1;
    public GameObject Panel2;
    public TMP_Dropdown Gender;

    void Start()
    {
        Name.onValueChanged.AddListener(delegate {CheckEmpty(); });
        Play.onClick.AddListener(PlayGame);
        Quit.onClick.AddListener(QuitGame);
    }

    void CheckEmpty()
    {
        Play.gameObject.SetActive(Name.text != "");
    }
    void PlayGame()
    {
        MainManager.Instance.PlayerName = Name.text;
        MainManager.Instance.Gender = Gender.options[Gender.value].text;
        if (MainManager.Instance.Gender == "Boy")
        {
            MainManager.Instance.ArgueChild = Resources.Load<Sprite>("ArgueGirl");
            MainManager.Instance.WorkChild = Resources.Load<Sprite>("WorkGirl");
            MainManager.Instance.TransChild = Resources.Load<Sprite>("TransGirl");
        }
        else
        {
            MainManager.Instance.ArgueChild = Resources.Load<Sprite>("ArgueBoy");
            MainManager.Instance.WorkChild = Resources.Load<Sprite>("WorkBoy");
            MainManager.Instance.TransChild = Resources.Load<Sprite>("TransBoy");
        }
        SceneManager.LoadScene(8);
    }
    void QuitGame()
    {
        Application.Quit();
    }
    
    void Change()
    {
        if (Panel1.activeSelf)
        {
            Panel1.gameObject.SetActive(false);
            Panel2.gameObject.SetActive(true);
        }
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => Change();
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
