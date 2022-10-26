using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public float Speed = 5.0f;
    public GameObject NextBox;
    public GameObject Boundary;
    void Update()
    {
        if (gameObject.name == "Plate2")
        {
            if (MainManager.Instance.Question1Done && gameObject.transform.position.z > 0)
            {
                gameObject.transform.Translate(0, 0, -Speed * Time.deltaTime);
                if (gameObject.transform.position.z < 0)
                {
                    NextBox.gameObject.SetActive(true);
                    Boundary.gameObject.SetActive(false);
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f);
                }
            }
        }
        else if (gameObject.name == "Plate3")
        {
            if (MainManager.Instance.Question2Done && gameObject.transform.position.z < 0)
            {
                gameObject.transform.Translate(0, 0, Speed * Time.deltaTime);
                if (gameObject.transform.position.z > 0)
                {
                    NextBox.gameObject.SetActive(true);
                    Boundary.gameObject.SetActive(false);
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f);
                }
            }
        }
        else if (gameObject.name == "Plate4")
        {
            if (MainManager.Instance.Question3Done)
            {
                Boundary.gameObject.SetActive(false);
            }
        }
    }
}
