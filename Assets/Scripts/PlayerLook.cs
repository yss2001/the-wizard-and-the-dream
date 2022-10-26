using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera PlayerCamera;
    private float XRotation = 0.0f;
    private float XSensitivity = 30.0f;
    private float YSensitivity = 30.0f;

    public void ProcessLook(Vector2 Input)
    {
        if (MainManager.Instance.ControlAllowed)
        {
            float MouseX = Input.x;
            float MouseY = Input.y;
            XRotation -= (MouseY * Time.deltaTime) * YSensitivity;
            XRotation = Mathf.Clamp(XRotation, -80.0f, 80.0f);
            PlayerCamera.transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
            transform.Rotate(Vector3.up * (MouseX * Time.deltaTime) * XSensitivity);
        }
    }
}
