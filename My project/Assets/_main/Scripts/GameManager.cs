using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _vida = 100;
    [SerializeField] private PlayerMovement _movimientodeljugador;
    [SerializeField] private IUManager _iuManager;
    [SerializeField] private GameObject _escudo;

    [SerializeField] private GameObject _player;

    [SerializeField] private PlayerController _playerController;

    [SerializeField] private float _alturademuerte = -10f;
    [SerializeField] private bool _MurioPorAltura = false;

    [SerializeField] private bool[] gemas = new bool[5];
    [SerializeField] private Collider colliderPuerta;

    [SerializeField] private int siguienteNivel;

    [SerializeField] private AudioManager _audioManager;

    private void Update()
    {
        if (!_MurioPorAltura && _player.activeSelf && _player.transform.position.y < _alturademuerte)
        {
            _MurioPorAltura = true;
            MuerteInstantanea();
        }
    }

    public void RestarVida(int _Damage)
    {
        Debug.Log("resta vida");

        if (_escudo.activeSelf)
        {
            Debug.Log("escudo bloquea");
            _movimientodeljugador.RomperEscudo();
            return;
        }

        Debug.Log("se rompio el escudo, se resta vida");

        if (_vida > 0)
        {
            _vida -= _Damage;

            _audioManager.SonidoDaño();

            _iuManager.ActualizarColorVida(_vida);
            _iuManager.FillAmount_Colorvida(_vida / 100f);
        }

        if (_vida <= 0)
        {
            _movimientodeljugador.gameObject.SetActive(false);
            Perdiste();

            Debug.Log("Se muriooo");
        }
    }

    public void CurarVida(int _curacion)
    {
        if (_vida > 0)
        {
            _vida += _curacion;

            if (_vida > 100)
            {
                _vida = 100;
            }

            _iuManager.ActualizarColorVida(_vida);
            _iuManager.FillAmount_Colorvida(_vida / 100f);
        }
    }

    public void Perdiste()
    {
        if (_vida <= 0)
        {
            _player.SetActive(false);
            _audioManager.SonidoMuerte();
            _iuManager.juegoterminado();
        }
    }

    // REINICIAR NIVEL ACTUAL

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // MUERTE INSTANTÁNEA

    public void MuerteInstantanea()
    {
        _player.SetActive(false);
        _audioManager.SonidoMuerte();
        _iuManager.juegoterminado();
    }

    // GEMAS

    public void RecogerGema(int numeroGema)
    {
        gemas[numeroGema] = true;
        _audioManager.SonidoGema();
        _iuManager.MostrarGema(numeroGema);
        ComprobarGemas();
    }

    private void ComprobarGemas()
    {
        for (int i = 0; i < gemas.Length; i++)
        {
            if (gemas[i] == false)
            {
                return;
            }
        }

        AbrirPuerta();
    }

    private void AbrirPuerta()
    {
        colliderPuerta.isTrigger = true;
    }

    // ESCUDO

    public void RecogerEscudo()
    {
        _movimientodeljugador.ActivarEscudo();
        _audioManager.SonidoEscudo();
    }

    // VELOCIDAD

    public void RecogerVelocidad()
    {
        _audioManager.SonidoVelocidad();
        _movimientodeljugador.IncrementoVelocidad(5f);
        _movimientodeljugador.IncrementoSalto(10f);
        _movimientodeljugador.ActivateSeedPowerUp(5, 5);
       
    }
    // NIVELES

    public void IrAlSiguienteNivel()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(siguienteNivel);
        _audioManager.SonidoMeta();
    }

    // PAUSA

    public void Pausar()
    {
        Time.timeScale = 0f;
        _iuManager.MostrarPausa();
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        _iuManager.OcultarPausa();
    }

    // MENU PRINCIPAL

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel 1");
    }

    public void Creditos()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Creditos");
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void SonidoSalto()
    {
        _audioManager.SonidoSalto();
    }
}