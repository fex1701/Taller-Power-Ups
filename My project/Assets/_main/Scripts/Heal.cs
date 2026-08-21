using UnityEngine;
public class Heal : MonoBehaviour
{
  
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _heal;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             gameObject.SetActive(false);
            _gameManager.CurarVida(_heal);
        }

    }


}