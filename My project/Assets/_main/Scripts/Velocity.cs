using Unity.VisualScripting;
using UnityEngine;

public class Velocity : MonoBehaviour
{


    [SerializeField] private float IncrementoVelocidad = 5f;
    private float Velocidad = 10f;
    [SerializeField] private PlayerMovement MovimientodelJugador;

    [SerializeField] private float IncrementodeVelocidadSalto = 10f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);


            collision.GetComponent<PlayerMovement>().IncrementoVelocidad(IncrementoVelocidad);
            collision.GetComponent<PlayerMovement>().IncrementoSalto(IncrementodeVelocidadSalto);
            MovimientodelJugador.ActivateSeedPowerUp(5, 5);

        }

    }
}

