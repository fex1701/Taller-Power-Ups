using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _damage;

    private bool puedeHacerDanio = true;
    [SerializeField] private float tiempoEntreDanios = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && puedeHacerDanio)
        {
            puedeHacerDanio = false;

            gameManager.RestarVida(_damage);

            Invoke(nameof(ReactivarDanio), tiempoEntreDanios);
        }
    }

    private void ReactivarDanio()
    {
        puedeHacerDanio = true;
    }
}