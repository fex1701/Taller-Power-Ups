using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _damage;

    private bool puedeHacerDaño = true;
    [SerializeField] private float tiempoEntreDaños = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDaño)
        {
            puedeHacerDaño = false;

            gameManager.RestarVida(_damage);

            Invoke(nameof(ReactivarDanio), tiempoEntreDaños);
        }
    }

    private void ReactivarDanio()
    {
        puedeHacerDaño = true;
    }
}