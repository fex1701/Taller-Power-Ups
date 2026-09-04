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
            _iuManager.juegoterminado();
        }


    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MuerteInstantanea()
    {
        _player.SetActive(false);
        _iuManager.juegoterminado();

    }

    public void RecogerGema(int numeroGema)
    {
        gemas[numeroGema] = true;

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
    public void IrAlSiguienteNivel(Transform posicionMeta)
    {
        _player.transform.position = posicionMeta.position;

        for (int i = 0; i < gemas.Length; i++)
        {
            gemas[i] = false;
        }

        colliderPuerta.isTrigger = false;
    }
}