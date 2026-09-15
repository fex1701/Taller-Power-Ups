using System.Collections;
using TMPro;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController ControladordelJugador;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float salto = 5f;
    [SerializeField] private Animator AnimadordeEscudo;
    [SerializeField] private GameObject Escudo;
    [SerializeField] private PlayerAnimations AnimacionesdelJugador;
    [SerializeField] private TMP_Text NumeroVelocidad;
    [SerializeField] private GameObject ContadorVelocidad;

    private float normalVelocidad;

    private float normalSalto;

    private int cantidadVelocidad = 0;
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
        if (!ControladordelJugador.estaSaltando || !ControladordelJugador.EsSuelo)
        {
            return;
        }
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, salto, rb.linearVelocity.z);
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
        yield return new WaitForSeconds(time);

        velocidad = normalVelocidad;
        salto = normalSalto;

        cantidadVelocidad = 0;
        NumeroVelocidad.text = cantidadVelocidad.ToString();
        ContadorVelocidad.SetActive(false);

        Debug.Log("revertido");

        AnimacionesdelJugador.DesactivarAnimaciondeVelocidad();
    }

    public void ActivateSeedPowerUp(float amount, int time)
    {
        IncrementoVelocidad(amount);
        StartCoroutine(BonusSpeed(time));
        AnimacionesdelJugador.ActivarAnimaciondeVelocidad();
        IncrementoSalto(amount);

        cantidadVelocidad++;
        NumeroVelocidad.text = cantidadVelocidad.ToString();

        ContadorVelocidad.SetActive(true);
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
}