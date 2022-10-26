using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroPanelLevel3 : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnimator;
    public GameObject BW;
    int Slide = 0;
    public TextMeshProUGUI Text;

    void ClosePanel()
    {
        PanelAnimator.Play("SlideDown");
        BW.gameObject.GetComponent<Animator>().Play("GameBWDown");
    }

    void Next()
    {
        Slide += 1;
        Text.text = "The question marks are at a height; so I am giving you the ability to jump using a Spacebar. Move around the boxes of different heights, jump on them to reach the question mark. Good Luck!";
    }

    public void ButtonAction()
    {
        if (Slide == 0)
        {
            Next();
        }
        else
        {
            ClosePanel();
            MainManager.Instance.ControlAllowed = true;
            StartCoroutine(CloseCoroutine());
        }
    }
    IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(1);
        Panel.gameObject.SetActive(false);
    }

}
