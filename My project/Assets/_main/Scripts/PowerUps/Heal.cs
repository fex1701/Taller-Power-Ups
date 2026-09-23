using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameManager.CurarVida(_heal);
        }
    }
}
