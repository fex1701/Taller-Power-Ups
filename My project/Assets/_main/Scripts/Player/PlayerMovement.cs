using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 5f;
    private void FixedUpdate()
    {
        Move();
        RotateTowardsMovementDirection();
        Jump();
    }
    private void Move()
    {
        Vector2 playerImputs = playerController.MoveValue;
        Vector3 playerDirection = new Vector3(playerImputs.x, rb.linearVelocity.y, playerImputs.y);

        rb.linearVelocity = new Vector3(playerImputs.x * velocity, rb.linearVelocity.y, playerImputs.y * velocity);
    }
    private void RotateTowardsMovementDirection()
    {
        Vector2 playerImputs = playerController.MoveValue;
        if (playerImputs.sqrMagnitude <= 0.0f)
        {
            return;
        }
        Vector3 direction = new Vector3(
            playerImputs.x,
            0f,
            playerImputs.y
            );
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(targetRotation);
    }
    private void Jump()
    {
        if (!playerController.isJump || !playerController.isGround)
        {
            return;
        }
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }


}