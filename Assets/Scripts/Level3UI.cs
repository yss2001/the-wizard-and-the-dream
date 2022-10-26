using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level3UI : MonoBehaviour
{
    Dictionary<string, string> Responses = new Dictionary<string, string>();
    public GameObject Question1Panel;
    public GameObject Question2Panel;
    public GameObject Question3Panel;
    public GameObject Verdict1Panel;
    public GameObject Verdict2Panel;
    public GameObject Verdict3Panel;
    public TextMeshProUGUI Verdict1Text;
    public TextMeshProUGUI Verdict2Text;
    public TextMeshProUGUI Verdict3Text;
    public GameObject HelpPanel;
    public GameObject SuccessPanel;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject BW;
    public GameObject AssistPanel;
    public GameObject FriendsPanel;
    bool CrossedIsland1 = false;
    public Transform PlayerPosition;
    public Button FriendsButton;
    public Image ArgueChild;
    public Image WorkChild;
    public Image TransChild;
    
    public void Start()
    {
        Responses.Add("Q1B1", "It's fine to have different opinions. You could explain your point of view when they cool down.");
        Responses.Add("Q1B2", "You want to argue because you want to prove you are right. Think about it - what have you gained by winning a silly argument?");
        Responses.Add("Q2B1", "It is nice to be devoted to work as your duty. However, pause and reflect - is proving that you are a hard worker more precious than your health?");
        Responses.Add("Q2B2", "Physical health is very important. You don't have to overstrain to show you are better - taking help and sharing the load is key.");
        Responses.Add("Q3B1", "A person should be judged by their values, ethics and skills and not by their chosen identity. Next time, try to avoid this prejudice.");
        Responses.Add("Q3B2", "Transgender people are people too! Unfortunately, many people have this prejudice, and we have to play our part in changing it.");
    }

    public void ShowFriends()
    {
        HelpPanel.gameObject.SetActive(false);
        //BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        MainManager.Instance.ControlAllowed = false;
        FriendsPanel.gameObject.SetActive(true);
    }
    public void ShowQuestion(int id)
    {
        if (id == 1)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Question1Panel.gameObject.SetActive(true);
            //Question1Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
        else if (id == 2)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Question2Panel.gameObject.SetActive(true);
            //Question2Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
        else
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Question3Panel.gameObject.SetActive(true);
            //Question3Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
    }
    public void HideQuestion(int id)
    {
        if (id == 1)
        {
            Question1Panel.gameObject.SetActive(false);
        }
        else if (id == 2)
        {
            Question2Panel.gameObject.SetActive(false);
        }
        else
        {
            Question3Panel.gameObject.SetActive(false);
        }
    }

    public void ShowVerdict(int id, string Text)
    {
        if (id == 1)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Verdict1Text.text = Responses[Text];
            Verdict1Panel.gameObject.SetActive(true);
            //Verdict1Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
        else if (id == 2)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Verdict2Text.text = Responses[Text];
            Verdict2Panel.gameObject.SetActive(true);
            //Verdict2Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
        else
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            Verdict3Text.text = Responses[Text];
            Verdict3Panel.gameObject.SetActive(true);
            //Verdict3Panel.gameObject.GetComponent<Animator>().Play("SlideRight");
        }
    }

    public void ShowSuccessPanel()
    {
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        MainManager.Instance.ControlAllowed = false;
        SuccessPanel.gameObject.SetActive(true);
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Help.performed += context => Help();
        MainManager.Instance.InLevel3 = true;
        FriendsButton.onClick.AddListener(ShowFriends);
        ArgueChild.sprite = MainManager.Instance.ArgueChild;
        WorkChild.sprite = MainManager.Instance.WorkChild;
        TransChild.sprite = MainManager.Instance.TransChild;
    }
    void Help()
    {
        if (MainManager.Instance.ControlAllowed)
        {
            MainManager.Instance.ControlAllowed = false;
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            HelpPanel.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (!CrossedIsland1 && PlayerPosition.transform.position.x >= -75)
        {
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            AssistPanel.gameObject.SetActive(true);
            MainManager.Instance.ControlAllowed = false;
            CrossedIsland1 = true;
        }
    }
    private void OnEnable()
    {
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        Ground.Enable();
    }
    private void OnDisable()
    {
        Ground.Disable();
    }
}
