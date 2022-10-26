using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroPanelChores : MonoBehaviour
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
        Text.text = "You have a broom with you. Go near a water puddle and press Enter to start cleaning it. Let's give your mother some rest!";
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
