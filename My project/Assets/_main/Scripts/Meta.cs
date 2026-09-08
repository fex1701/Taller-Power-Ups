using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.IrAlSiguienteNivel();
        }
    }
}