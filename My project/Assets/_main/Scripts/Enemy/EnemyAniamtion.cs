using UnityEngine;
using UnityEngine.AI;

public class EnemyAniamtion : MonoBehaviour
{

    public NavMeshAgent agente;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()


    {

        agente = GetComponent<NavMeshAgent>();

        bool IsRunning1 = agente.transform.position == agente.destination;
        animator.SetBool("IsRunning1", IsRunning1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
