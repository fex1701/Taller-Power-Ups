using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

            playerMovement.ActivateShield();

            Destroy(gameObject);
        }
    }
}
