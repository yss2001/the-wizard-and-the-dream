using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    public float Speed = 5.0f;
    private bool Grounded;
    public float Gravity = -9.8f;
    public float JumpHeight = 1.0f;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Grounded = Controller.isGrounded;
    }

    public void ProcessMove(Vector2 Input)
    {
        if (MainManager.Instance.ControlAllowed)
        {
            Vector3 MoveDirection = Vector3.zero;
            MoveDirection.x = Input.x;
            MoveDirection.z = Input.y;
            Controller.Move(transform.TransformDirection(MoveDirection) * Speed * Time.deltaTime);
            Velocity.y += Gravity * Time.deltaTime;
            if (Grounded && Velocity.y < 0)
            {
                Velocity.y = -2.0f;
            }
            Controller.Move(Velocity * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (Grounded && MainManager.Instance.InLevel3)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
        }
    }
  
}
