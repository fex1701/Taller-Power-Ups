using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecogerVelocidad();

            Destroy(gameObject);
        }
    }
}