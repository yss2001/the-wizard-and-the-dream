using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFall : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -20.0f)
        {
            gameObject.GetComponent<CharacterController>().gameObject.SetActive(false);
            transform.position = new Vector3(-94.3f, 5f, 0f);
            gameObject.GetComponent<CharacterController>().gameObject.SetActive(true);
        }
    }
}
