using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    [SerializeField] private PlayerController playerController;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float velocity = 10f;

    private float normalVelocity;

    [SerializeField] private PlayerAnimations playerAnimations;

    [SerializeField] private float jumpForce = 5f;

    private float normalJump;

    private void Awake()
    {
        normalVelocity = velocity;
        normalJump = jumpForce;
    }

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


    public void IncreaseJump(float amount)
    {

        jumpForce += amount;
    }

    public void IncreaseSpeed(float amount)
    {
        velocity += amount;


    }

    public void DecreaseSpeed(float amount)
    {
        velocity =- 5f;
        jumpForce = 10;
    }
    public IEnumerator BonusSpeed(int time)
    {
        //incremento
        yield return new WaitForSeconds(time);
        //des
        velocity = normalVelocity;
        jumpForce = normalJump;
        Debug.Log("revertido");

        playerAnimations.DeactivateSpeedAnimation();
    }

    public void ActivateSpeedPowerUp(float amount, int time)
    {
        IncreaseSpeed(amount);
        StartCoroutine(BonusSpeed(time));
        playerAnimations.ActivateSpeedAnimation();
        IncreaseJump(amount);
    }

}

