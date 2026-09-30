using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PowerUpManager powerUpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecogerEscudo();

            powerUpManager.RecogerPowerUp();
        }
    }
}