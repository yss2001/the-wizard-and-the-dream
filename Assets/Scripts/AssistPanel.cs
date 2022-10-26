using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AssistPanel : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnimator;
    public GameObject BW;
    int Slide = 0;
    public TextMeshProUGUI Text;
    public Button HelpButton;

    void ClosePanel()
    {
        PanelAnimator.Play("SlideDown");
        BW.gameObject.GetComponent<Animator>().Play("GameBWDown");
    }

    void Next()
    {
        Slide += 1;
        Text.text = "A new button has been added to the help screen. You can click that to take their help and reach the question faster; or you can keep doing it alone!";
        HelpButton.gameObject.SetActive(true);
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
