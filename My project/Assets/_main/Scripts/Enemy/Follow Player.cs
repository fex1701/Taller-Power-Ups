using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agente;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float tiempoEntreDaños = 0.5f;
    [SerializeField] private int _damage;
    public Transform jugador;
    private bool puedeHacerDaño = true;
    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        agente.destination = jugador.position;

        
        
    }
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