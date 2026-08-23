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
        ActualizarAnimaciondeMovimiento();
        ActualizarAnimaciondeSalto();
    }

    private void ActualizarAnimaciondeMovimiento()
    {
        bool IsRunning = playerController.ValordeMovimiento.sqrMagnitude > 0.01f;

        animator.SetBool("IsRunning", IsRunning);
        
       

    }

    private void ActualizarAnimaciondeSalto()
    {


        //animator.SetBool("IsGround", playerController.isJump);

       bool IsJumping = playerController.estaSaltando;

        //animator.SetBool("IsGround", IsJumping);

        if (IsJumping == true)
        {
            animator.SetBool("IsJumping", true);
            
        }
        if (IsJumping == false)
        {
            animator.SetBool("IsJumping", false);
            
        }

        if (playerController.EsSuelo == true)
        {
            animator.SetBool("IsGround", true);
        }

        if (playerController.EsSuelo == false)
        {
            animator.SetBool("IsGround", false);
        }

       if (playerController.estaSaltando == false && playerController.EsSuelo == false)
        {
            animator.SetBool("IsRunning", false);
        }

       

    }

    public void ActivarAnimaciondeVelocidad()
    {
        animator.speed = 1.5f;
    }

    public void DesactivarAnimaciondeVelocidad()
    {
        animator.speed = 1f;
    }
}
