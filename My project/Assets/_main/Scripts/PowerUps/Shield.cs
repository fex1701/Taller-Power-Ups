using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecogerEscudo();

            Destroy(gameObject);
        }
    }
}