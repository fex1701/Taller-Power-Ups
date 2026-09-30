using UnityEngine;
using UnityEngine.AI;

public class EnemyAniamtion : MonoBehaviour
{

    public NavMeshAgent agente;
    [SerializeField] private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        bool corriendo = agente.velocity.magnitude > 0.1f;
        animator.SetBool("IsRunning1", corriendo);
    }
}
