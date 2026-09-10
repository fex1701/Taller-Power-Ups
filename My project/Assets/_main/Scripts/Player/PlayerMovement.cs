using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController ControladordelJugador;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float salto = 5f;
    [SerializeField] private Animator AnimadordeEscudo;
    [SerializeField] private GameObject Escudo;

    [SerializeField] private bool saltoRealizado;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private PlayerAnimations AnimacionesdelJugador;

    private float normalVelocidad;

    private float normalSalto;

    private void Awake()
    {
        normalVelocidad = velocidad;
        normalSalto= salto;
    }


    
    private void FixedUpdate()
    {
        Mover();
        Rotacion();
        Salto();
    }
    private void Mover()
    {
        Vector2 playerImputs = ControladordelJugador.ValordeMovimiento;
        new Vector3(playerImputs.x, rb.linearVelocity.y, playerImputs.y);

        rb.linearVelocity = new Vector3(playerImputs.x * velocidad, rb.linearVelocity.y, playerImputs.y * velocidad);
    }
    private void Rotacion()
    {
        Vector2 playerImputs = ControladordelJugador.ValordeMovimiento;
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
   

    private void Salto()
    {
        if (!ControladordelJugador.estaSaltando || !groundCheck.EsSuelo || saltoRealizado)
        {
            return;
        }

        saltoRealizado = true;

        rb.AddForce(Vector3.up * salto, ForceMode.Impulse);

    }

    public void IncrementoSalto (float amount)
    {
        salto += amount;
    }

    public void IncrementoVelocidad (float amount)
    {
        velocidad += amount;
    }

    
    public IEnumerator BonusSpeed(int time)
    {
        //incremento
        yield return new WaitForSeconds(time);
        //des
        velocidad = normalVelocidad;
        salto = normalSalto;
        Debug.Log("revertido");

        AnimacionesdelJugador.DesactivarAnimaciondeVelocidad();
    }

    public void ActivateSeedPowerUp(float amount, int time)
    {
        IncrementoVelocidad(amount);
        StartCoroutine(BonusSpeed(time));
        AnimacionesdelJugador.ActivarAnimaciondeVelocidad();
        IncrementoSalto(amount);
    }



    public void ActivarEscudo()
    {
        Escudo.SetActive(true);
        EscudoAparece();
    }
    public void EscudoAparece()
    {
        AnimadordeEscudo.SetTrigger("Appear");
    }

    public void EscudoDesaparece()
    {
        AnimadordeEscudo.SetTrigger("Disappear");
    }


    public void RomperEscudo()
    {
        EscudoDesaparece();
        StartCoroutine(DesactivarEscudo());
    }

    private IEnumerator DesactivarEscudo()
    {
        yield return new WaitForSeconds(3f);

        Escudo.SetActive(false);
    }

    private void Update()
    {
        if (!groundCheck.EsSuelo)
        {
            saltoRealizado = false;
        }
    }
}