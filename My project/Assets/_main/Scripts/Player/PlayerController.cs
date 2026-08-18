using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;

    public Vector2 MoveValue { get; private set; }
    public bool isJump { get; private set; }

    public bool isGround;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        Physics.gravity = new Vector3(0f, -100f, 0f);
    }

    void Update()
    {
        MoveValue = moveAction.ReadValue<Vector2>();
        isJump = jumpAction.IsPressed();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision) 
    { 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}