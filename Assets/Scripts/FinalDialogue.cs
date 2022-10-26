using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalDialogue : MonoBehaviour
{
    public Button DialogueButton;
    public TextMeshProUGUI ButtonText;
    int SlideNumber = 0;
    public TextMeshProUGUI Dialogue;
    public GameObject BW;

    void Next()
    {
        SlideNumber += 1;
        if (SlideNumber == 1)
        {
            Dialogue.text = "You see, getting this crystal was not the important thing at all! My main goal was to help you!";
        }
        else if (SlideNumber == 2)
        {
            Dialogue.text = "In the real world, you never share your problems with anyone, thinking you will appear weak...";
        }
        else if (SlideNumber == 3)
        {
            Dialogue.text = "...but that only affects you negatively! In life, there are many situations where asking for help can make it easier.";
        }
        else if (SlideNumber == 4)
        {
            Dialogue.text = "Just like how it helped you finish this dream! There were many tasks you couldn't do alone, but different people aided you on the way.";
        }
        else if (SlideNumber == 5)
        {
            Dialogue.text = "Now, will you promise me that you would share your burdens with your loved ones?";
            ButtonText.text = "YES!";
        }
        else if (SlideNumber == 6)
        {
            Dialogue.text = "That's great! The portal is waiting for you - go on, complete the dream and wake up for the new day!";
            ButtonText.text = "CONTINUE";
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("SlideDown");
            BW.gameObject.GetComponent<Animator>().Play("GameBWDown");
            MainManager.Instance.ControlAllowed = true;
            StartCoroutine(CloseCoroutine());
        }
    }

    IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    void Awake()
    {
        DialogueButton.onClick.AddListener(Next);
    }

    private void OnEnable()
    {
        SlideNumber = 0;
        ButtonText.text = "CONTINUE";
        Dialogue.text = "Woohoo, you are almost there my friend! Thank you for finding my crystal! Although, I have to tell you one thing...";
    }

}
