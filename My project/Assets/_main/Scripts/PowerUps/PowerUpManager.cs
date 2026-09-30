using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 5f;

    private Collider _collider;
    private Renderer _renderer;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }

    public void RecogerPowerUp()
    {
        StartCoroutine(DisableAndRespawnRoutine());
    }

    private IEnumerator DisableAndRespawnRoutine()
    {
        _collider.enabled = false;
        _renderer.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        _collider.enabled = true;
        _renderer.enabled = true;
    }
}