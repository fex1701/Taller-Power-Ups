using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool EsSuelo { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            EsSuelo = true;
            Debug.Log("Detecto suelo");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            EsSuelo = false;
            Debug.Log("Dejo de detectar suelo");
        }
    }
}