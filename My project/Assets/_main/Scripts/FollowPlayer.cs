using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform jugador;
    private void Start()
    {
       agente  = GetComponent<NavMeshAgent>();
    }

   
     private void Update()
    {
        agente.destination = jugador.position;
    }
}
