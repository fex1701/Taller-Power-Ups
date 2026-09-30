using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PowerUpManager powerUpManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.RecogerVelocidad();

            powerUpManager.RecogerPowerUp();
        }
    }
}