using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LabUI : MonoBehaviour
{
    public Transform PlayerPosition;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI SamplesCollected;
    public GameObject Panel;
    public GameObject HelpPanel;
    private PlayerInput Input;
    private PlayerInput.GroundActions Ground;
    public GameObject Sample1;
    public GameObject Sample2;
    public GameObject Sample3;
    public TextMeshProUGUI SuccessText;
    public TextMeshProUGUI DetectorPercent;
    public GameObject BW;

    void Help()
    {
        if (MainManager.Instance.ControlAllowed)
        {
            MainManager.Instance.ControlAllowed = false;
            BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
            HelpPanel.gameObject.SetActive(true);
        }
    }

    public void Show(string Text)
    {
        if (Info.gameObject.activeSelf)
            Info.gameObject.SetActive(false);
        Info.text = Text;
        Info.gameObject.SetActive(true);
    }

    public void UpdateSamplesCollected()
    {
        SamplesCollected.text = $"Samples Collected: {MainManager.Instance.SamplesCollected} / 3";
    }

    public void ShowPanel()
    {
        /*if (MainManager.Instance.ChoresCompleted)
        {
            SuccessText.text += " Since you have already finished helping your mother, you should now be able to collect the key. Good Luck!";
        }
        else
        {
            SuccessText.text += " I have made catching the key a bit easier, but you still have to finish the task in the other door. Good Luck!";
        }*/
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
        Panel.gameObject.SetActive(true);
    }

    void CheckProximity()
    {
        float Sample1Distance = Vector3.Distance(PlayerPosition.position, Sample1.transform.position);
        float Sample2Distance = Vector3.Distance(PlayerPosition.position, Sample2.transform.position);
        float Sample3Distance = Vector3.Distance(PlayerPosition.position, Sample3.transform.position);

        float Closest = Math.Min(Sample1Distance, Math.Min(Sample2Distance, Sample3Distance));
        if (Closest >= 10.0f)
        {
            DetectorPercent.text = "0";
            DetectorPercent.color = new Color32(255, 255, 255, 255);
            DetectorPercent.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 255, 255, 255));

        }
        else
        {
            
            float Value = (10.0f - Closest) / 8.0f;
            DetectorPercent.text = ((int)(Value * 100)).ToString();
            if (Closest <= 2.0f)
            {
                DetectorPercent.text = "100";
                DetectorPercent.color = new Color32(0, 255, 0, 255);
                DetectorPercent.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(0, 255, 0, 255));
            }
            else
            {
                DetectorPercent.color = new Color32(255, 255, 255, 255);
                DetectorPercent.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 255, 255, 255));
            }
        }
    }
    void Update()
    {
        if (MainManager.Instance.SamplesCollected < 3)
        {
            CheckProximity();
        }
        else
        {
            DetectorPercent.text = "0";
            DetectorPercent.color = new Color32(255, 255, 255, 255);
            DetectorPercent.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 255, 255, 255));
        }
    }
    void Awake()
    {
        Input = new PlayerInput();
        Ground = Input.Ground;
        Ground.Help.performed += context => Help();
        BW.gameObject.GetComponent<Animator>().Play("GameBWUp");
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
