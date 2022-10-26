using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void OnCollisionEnter(Collision a)
    {
        Debug.Log("From boat.");
    }
}
