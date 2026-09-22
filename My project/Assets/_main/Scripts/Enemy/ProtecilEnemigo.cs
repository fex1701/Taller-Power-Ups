using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public int _damage = 10;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.RestarVida(_damage);
            Destroy(gameObject);
        }
    }
}
