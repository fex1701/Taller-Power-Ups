using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static readonly int IsRunningParameter =
        Animator.StringToHash("IsRunning");

    private static readonly int IsJumpingParameter =
        Animator.StringToHash("IsGround");
    // Update is called once per frame
    void Update()
    {
        UpdateMovementAnimaton();
        UpdateJumpingAnimation();
    }

    private void UpdateMovementAnimaton()
    {
        bool IsRunning = playerController.MoveValue.sqrMagnitude > 0.01f;

        animator.SetBool("IsRunning", IsRunning);
        
       

    }

    private void UpdateJumpingAnimation()
    {


        //animator.SetBool("IsGround", playerController.isJump);

       bool IsJumping = playerController.isJump;

        //animator.SetBool("IsGround", IsJumping);

        if (IsJumping == true)
        {
            animator.SetBool("IsJumping", true);
            
        }
        if (IsJumping == false)
        {
            animator.SetBool("IsJumping", false);
            
        }

        if (playerController.isGround == true)
        {
            animator.SetBool("IsGround", true);
        }

        if (playerController.isGround == false)
        {
            animator.SetBool("IsGround", false);
        }

       if (playerController.isJump == false && playerController.isGround == false)
        {
            animator.SetBool("IsRunning", false);
        }

       
    }
}
