using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level0UI : MonoBehaviour
{
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public TextMeshProUGUI Info;
    public GameObject MiniWizard;
    public GameObject IntroPanel;
    public TextMeshProUGUI SlideContent;
    public Button Next;
    public TextMeshProUGUI ButtonText;
    int SlideNumber = 0;
    public GameObject Vignette;
    public GameObject BW;

    public void NextSlide()
    {
        if (SlideNumber == 4)
        {
            SceneManager.LoadScene(2);
        }
        SlideNumber += 1;
        if (SlideNumber == 1)
        {
            ButtonText.text = "My dream! How can I help you?";
            SlideContent.text = "Don't worry! You are dreaming, and I am The Friendly Wizard. I have a small favour to ask you...";
        }
        else if (SlideNumber == 2)
        {
            ButtonText.text = "Oh... but aren't you a wizard? Can't you use magic?";
            SlideContent.text = "Well, you see, I lost my crystal yesterday, and I hoped you could help me find them!";
        }
        else if (SlideNumber == 3)
        {
            ButtonText.text = "Hmmm... okay, I'll help you, Mr Wizard!";
            SlideContent.text = "My magic is limited without the crystal. I could find out it is one of these islands. But to get there, you need to go through some levels. Don't worry, they aren't too hard; I will always be there to guide you.";
        }
        else
        {
            ButtonText.text = "Click to enter Level 1.";
            SlideContent.text = "Oh, thank you my friend. I am sure we will have a fun journey!";
        }
    }
    public void Introduction()
    {
        MainManager.Instance.ControlAllowed = false;
        SlideNumber = 0;
        Info.gameObject.SetActive(false);
        MiniWizard.gameObject.SetActive(true);
        IntroPanel.gameObject.SetActive(true);
        SlideContent.text = "Welcome, my dear friend! How are you doing?";
        ButtonText.text = "I'm confused! Where am I?";
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        StartCoroutine(DelayControl());
        Next.onClick.AddListener(NextSlide);
    }

    IEnumerator DelayControl()
    {
        yield return new WaitForSeconds(19);
        MainManager.Instance.ControlAllowed = true;
        Info.gameObject.SetActive(true);
        Vignette.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        ButtonText.text = "I'm confused! Where am I?";
        SlideContent.text = "Welcome, my dear friend! How are you doing?";
        SlideNumber = 0;
        Ground.Enable();
    }
    private void OnDisable()
    {
        Ground.Disable();
    }
}
