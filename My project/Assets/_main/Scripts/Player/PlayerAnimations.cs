using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
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


        

       bool IsJumping = playerController.estaSaltando;



        animator.SetBool("IsJumping", IsJumping);

        animator.SetBool("IsGround", playerController.EsSuelo);

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
