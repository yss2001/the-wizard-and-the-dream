using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    public Transform BroomPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    int SweepNumber = 0;
    float ScaleFactor = 2.0f;
    public GameObject UIHandler;
    private Animator PuddleAnimator;

    void Clean()
    {
        Close = Vector3.Distance(BroomPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            PuddleAnimator.Play("Rotate");
            StartCoroutine(SweepCoroutine());
        }
    }
    IEnumerator SweepCoroutine()
    {
        yield return new WaitForSeconds(1);
        SweepNumber += 1;
        if (SweepNumber == 3)
        {
            MainManager.Instance.PuddlesCleaned += 1;
            if (MainManager.Instance.PuddlesCleaned == 3)
            {
                MainManager.Instance.ControlAllowed = false;
                UIHandler.GetComponent<ChoresUI>().ShowPanel();
                MainManager.Instance.ChoresCompleted = true;
            }
            RemovePuddle();
        }
        else
        {
            Vector3 InitialScale = gameObject.transform.localScale;
            //gameObject.transform.Rotate(0.0f, 45.0f, 0.0f);

            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y+45.0f, gameObject.transform.rotation.z), Time.deltaTime * 5f);
            gameObject.transform.localScale = new Vector3(InitialScale.x/ScaleFactor, InitialScale.y/ScaleFactor, InitialScale.z/ScaleFactor);
        }
    }
    void RemovePuddle()
    {
        UIHandler.GetComponent<ChoresUI>().Show("Cleaned!");
        UIHandler.GetComponent<ChoresUI>().UpdatePuddlesCleaned();
        Destroy(gameObject);
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => Clean();
        PuddleAnimator = gameObject.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        SweepNumber = 0;
        Ground.Enable();
    }
    private void OnDisable()
    {
        Ground.Disable();
    }
}
