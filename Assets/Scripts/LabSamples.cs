using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LabSamples : MonoBehaviour
{
    public Transform PlayerPosition;
    float DetectDistance = 2.0f;
    bool Close = false;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject UIHandler;
    bool Collected = false;
    private Animator SampleAnimator;
    void Interacted()
    {
        Close = Vector3.Distance(PlayerPosition.position, transform.position) <= DetectDistance;
        if (Close)
        {
            if (Collected)
            {
                UIHandler.GetComponent<LabUI>().Show("Already Collected!");
                return;
            }
            MainManager.Instance.SamplesCollected += 1;
            if (MainManager.Instance.SamplesCollected == 3)
            {
                MainManager.Instance.ControlAllowed = false;
                UIHandler.GetComponent<LabUI>().ShowPanel();
                MainManager.Instance.LabCompleted = true;
            }
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            SampleAnimator.Play("SampleGrow");
            string name = gameObject.name;
            UIHandler.GetComponent<LabUI>().Show("You collected " + name + "!");
            UIHandler.GetComponent<LabUI>().UpdateSamplesCollected();
            Collected = true;
        }
    }

    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Interact.performed += context => Interacted();
        SampleAnimator = gameObject.GetComponent<Animator>();
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
