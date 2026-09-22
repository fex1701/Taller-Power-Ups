using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoDaño;
    [SerializeField] private AudioClip sonidoSalto;
    [SerializeField] private AudioClip sonidoEscudo;
    [SerializeField] private AudioClip sonidoVelocidad;

    public void SonidoMuerte()
    {
        audioSource.PlayOneShot(sonidoMuerte);
    }

    public void SonidoDaño()
    {
        audioSource.PlayOneShot(sonidoDaño);
    }

    public void SonidoSalto()
    {
        audioSource.PlayOneShot(sonidoSalto);
    }

    public void SonidoEscudo()
    {
        audioSource.PlayOneShot(sonidoEscudo);
    }

    public void SonidoVelocidad()
    {
        audioSource.PlayOneShot(sonidoVelocidad);
    }
}