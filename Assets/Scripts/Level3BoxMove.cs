using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3BoxMove : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit Hit)
    {
        GameObject Body = Hit.gameObject;
        if (Body == null || Body.GetComponent<CharacterController>() == null || Body.tag != "Steps")
        {
            return;
        }
        Vector3 Direction = new Vector3(Hit.moveDirection.x, 0, Hit.moveDirection.z);
        //Vector3 targetPosition = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z-0.5f);
        //Body.transform.position = Vector3.Lerp(Body.transform.position, targetPosition, (Time.deltaTime*3)/Vector3.Distance(targetPosition, Body.transform.position));
        //Body.GetComponent<CharacterController>().gameObject.SetActive(false);
        //Body.transform.position += Direction * Time.deltaTime;
        //Body.GetComponent<CharacterController>().gameObject.SetActive(true);
        //Body.MovePosition(Body.position + Direction * Time.deltaTime);
        //Body.AddForce(Direction * 20.0f);
        Body.GetComponent<CharacterController>().Move(Direction * 3 * Time.deltaTime);
    }
}
