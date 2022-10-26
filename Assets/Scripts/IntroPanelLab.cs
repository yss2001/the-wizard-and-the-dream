using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroPanelLab : MonoBehaviour
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
        if (Slide == 1)
        {
            Text.text = "She is the first woman to win a Nobel Prize. She is also the first person and the only woman to win it twice; how cool!";
        }
        else if (Slide == 2)
        {
            Text.text = "But even such high achievers don't do everything by themselves. Today, she wants your assistance - her research requires some radioactive elements, and you can help her by searching for them!";
        }
        else if (Slide == 3)
        {
            Text.text = "I have given you a Geiger Counter, used to measure radiation levels. The closer you are to an element, the higher the number becomes; when it is green, you can capture it by pressing Enter!";
        }
    }

    public void ButtonAction()
    {
        if (Slide != 3)
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
