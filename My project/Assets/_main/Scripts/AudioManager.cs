using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoDaño;


    public void SonidoMuerte()
    {
        audioSource.PlayOneShot(sonidoMuerte);
    }
    public void SonidoDaño()
    {
        audioSource.PlayOneShot(sonidoDaño);
    }
}