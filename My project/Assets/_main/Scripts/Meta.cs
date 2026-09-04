using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform posicionSiguienteNivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.IrAlSiguienteNivel(posicionSiguienteNivel);
        }
    }
}