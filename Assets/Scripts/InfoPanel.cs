using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }
    IEnumerator OnEnableCoroutine()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
