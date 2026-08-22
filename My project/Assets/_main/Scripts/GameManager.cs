using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _vida = 100;
    [SerializeField] private PlayerMovement _jugador;
    [SerializeField] private IUManager _iuManager;
    [SerializeField] private GameObject _escudo;


    public void RestarVida(int _Damage)
    {
        Debug.Log("RESTAR VIDA LLAMADO");

        if (_escudo.activeSelf)
        {
            Debug.Log("ESCUDO BLOQUEÓ EL DAÑO");
            _escudo.SetActive(false);
            return;
        }

        Debug.Log("NO HAY ESCUDO, SE RESTA VIDA");

        if (_vida > 0)
        {
            _vida -= _Damage;

            _iuManager.ActualizarColorVida(_vida);
            _iuManager.FillAmount_Colorvida(_vida / 100f);
        }

        if (_vida <= 0)
        {
            _jugador.gameObject.SetActive(false);
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
            _iuManager.juegoterminado();
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}