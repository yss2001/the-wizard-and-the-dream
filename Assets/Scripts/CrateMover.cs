using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMover : MonoBehaviour
{
    public Transform Island2Big;
    public Transform Island2Med;
    public Transform Island3Big;
    public Transform Island3Med;

    public bool moveBig2 = false, moveMed2 = false;
    public bool moveBig3 = false, moveMed3 = false;

    void Update()
    {
        if (moveBig2)
        {
            Island2Big.transform.localPosition = Vector3.MoveTowards(Island2Big.transform.localPosition, new Vector3(1.41f, 4.06f, 0.03f), 1.0f * Time.deltaTime);
            
            if (Vector3.Distance(Island2Big.transform.localPosition, new Vector3(1.41f, 4.06f, 0.03f)) < 0.001)
            {
                moveBig2 = false;
            }
        }
        if (moveMed2)
        {
            Island2Med.transform.localPosition = Vector3.MoveTowards(Island2Med.transform.localPosition, new Vector3(-0.3f, 4.06f, 0.1f), 1.0f * Time.deltaTime);
            
            if (Vector3.Distance(Island2Med.transform.localPosition, new Vector3(-0.3f, 4.06f, 0.1f)) < 0.001)
            {
                moveMed2 = false;
            }
        }
        if (moveBig3)
        {
            Island3Big.transform.localPosition = Vector3.MoveTowards(Island3Big.transform.localPosition, new Vector3(2.23f, 4.06f, -0.07f), 1.0f * Time.deltaTime);
            
            if (Vector3.Distance(Island3Big.transform.localPosition, new Vector3(2.23f, 4.06f, -0.07f)) < 0.001)
            {
                moveBig3 = false;
            }
        }
        if (moveMed3)
        {
            Island3Med.transform.localPosition = Vector3.MoveTowards(Island3Med.transform.localPosition, new Vector3(0.67f, 4.06f, -0.08f), 1.0f * Time.deltaTime);
            
            if (Vector3.Distance(Island3Med.transform.localPosition, new Vector3(0.67f, 4.06f, -0.08f)) < 0.001)
            {
                moveMed3 = false;
            }
        }
    }
}
