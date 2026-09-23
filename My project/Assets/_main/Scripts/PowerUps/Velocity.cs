using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.RecogerVelocidad();
            
        }
    }
}