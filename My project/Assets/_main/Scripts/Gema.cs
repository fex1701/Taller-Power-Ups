using UnityEngine;

public class Gema : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int numeroGema;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecogerGema(numeroGema);

            gameObject.SetActive(false);
        }
    }
}