using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;
    bool Open = false;
    public GameObject Crystal;

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(1);
        UIHandler.GetComponent<Level3UI>().ShowSuccessPanel();
        Crystal.gameObject.SetActive(false);
    }

    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            if (!Open)
            {
                gameObject.GetComponent<Animator>().Play("Open");
                Open = true;
            }
            else if (!MainManager.Instance.CrystalCollected)
            {
                MainManager.Instance.CrystalCollected = true;
                Crystal.gameObject.GetComponent<Animator>().Play("CrystalCapture");
                StartCoroutine(Remove());
            }
        }
    }

    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => Interacted();
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
