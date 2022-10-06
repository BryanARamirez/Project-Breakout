using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody paddleRigidbody;
    private PaddleInputAction paddleInputAction;

    private void Awake()
    {
        paddleRigidbody = GetComponent<Rigidbody>();
        paddleInputAction = new PaddleInputAction();
        paddleInputAction.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = paddleInputAction.Paddle.Movement.ReadValue<Vector2>();
        paddleRigidbody.AddForce(new Vector3(moveVector.x, 0, moveVector.y) * 5f, ForceMode.Force);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        paddleRigidbody.AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Impulse);
    }
}
