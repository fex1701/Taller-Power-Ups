using UnityEngine;
using System.Collections;

public class EnemigoLanzador : MonoBehaviour
{
    public Transform jugador;
    public GameObject objetoLanzable;
    public Transform puntoLanzamiento;
    public Animator animator;

    public float rangoAtaque = 10f;
    public float fuerzaLanzamiento = 10f;
    public float tiempoEntreLanzamientos = 2f;
    public float tiempoAntesDeLanzar = 0.5f;

    private bool atacando = false;

    void Update()
    {
        if (jugador == null)
            return;

        float distancia = Vector3.Distance(
            transform.position,
            jugador.position
        );

        if (distancia <= rangoAtaque)
        {
            ApuntarAlJugador();

            if (!atacando)
            {
                StartCoroutine(Atacar());
            }
        }
    }

    void ApuntarAlJugador()
    {
        Vector3 direccion = jugador.position - transform.position;
        direccion.y = 0;

        if (direccion != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }

    IEnumerator Atacar()
    {
        atacando = true;

        animator.SetTrigger("Lanzar");

        yield return new WaitForSeconds(tiempoAntesDeLanzar);

        LanzarObjeto();

        yield return new WaitForSeconds(tiempoEntreLanzamientos);

        atacando = false;
    }

    void LanzarObjeto()
    {
        GameObject objeto = Instantiate(
            objetoLanzable,
            puntoLanzamiento.position,
            puntoLanzamiento.rotation
        );

        Rigidbody rb = objeto.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direccion =
                (jugador.position - puntoLanzamiento.position).normalized;

            rb.AddForce(
                direccion * fuerzaLanzamiento,
                ForceMode.Impulse
            );
        }
    }
}