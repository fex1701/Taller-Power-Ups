using UnityEngine;
using System.Collections;

public class ProyectilEnemigo : MonoBehaviour
{
    public int _damage = 10;
    public GameManager gameManager;

    private Coroutine autoDestruccion;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        autoDestruccion = StartCoroutine(DestruirDespuesDeTiempo(4f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.RestarVida(_damage);

            if (autoDestruccion != null)
            {
                StopCoroutine(autoDestruccion);
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator DestruirDespuesDeTiempo(float segundos)
    {
        yield return new WaitForSeconds(segundos);

        Destroy(gameObject);
    }
}
