using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManager gameManager;

    private bool sonidoSaltoReproducido;

    void Update()
    {
        ActualizarAnimaciondeMovimiento();
        ActualizarAnimaciondeSalto();
        RevisarAnimacionSalto();
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

        animator.SetBool("IsGround", groundCheck.EsSuelo);

        if (playerController.estaSaltando == false && groundCheck.EsSuelo == false)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void RevisarAnimacionSalto()
    {
        AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);

        bool estaEnJumpUp = estado.IsName("JumpUp");

        if (estaEnJumpUp && !sonidoSaltoReproducido)
        {
            sonidoSaltoReproducido = true;

            gameManager.SonidoSalto();
        }

        if (!estaEnJumpUp)
        {
            sonidoSaltoReproducido = false;
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