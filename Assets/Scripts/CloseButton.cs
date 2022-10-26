using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnimator;
    public GameObject BW;

    void ClosePanel()
    {
        PanelAnimator.Play("SlideDown");
        BW.gameObject.GetComponent<Animator>().Play("GameBWDown");
    }
    public void Close()
    {
        ClosePanel();
        MainManager.Instance.ControlAllowed = true;
        StartCoroutine(CloseCoroutine());
    }

    IEnumerator CloseCoroutine()
    {
        yield return new WaitForSeconds(1);
        Panel.gameObject.SetActive(false);
    }
}
