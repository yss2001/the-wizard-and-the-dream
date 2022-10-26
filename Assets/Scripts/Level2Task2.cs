using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Task2 : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit Hit)
    {
        if (MainManager.Instance.CanPushRock)
        {
            Rigidbody Body = Hit.collider.attachedRigidbody;
            if (Body == null || Body.name != "Obstacle2")
            {
                return;
            }
            Vector3 targetPosition = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z-0.5f);
            float Speed = MainManager.Instance.Obstacle2Choice == "" ? 0.25f : 3f;
            Body.transform.position = Vector3.Lerp(Body.transform.position, targetPosition, (Time.deltaTime*Speed)/Vector3.Distance(targetPosition, Body.transform.position));
        }
    }
}
