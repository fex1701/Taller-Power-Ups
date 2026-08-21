using System;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _life = 100;
    [SerializeField] private PlayerMovement _jugador;
    [SerializeField] private IUManager _iuManager;

    public void RestarVida(int _Damage)
    {
        if (_life > 0)
        {
            _life -= _Damage;

            _iuManager.ActualizarColorVida(_life);
            _iuManager.FillAmount_Colorvida(_life / 100f);
        }

        if (_life <= 0)
        {
            _jugador.gameObject.SetActive(false);
            Debug.Log("Se muriooo");
        }
    }


    public void CurarVida(int _curacion)
    {
        if (_life > 0)
        {
            _life += _curacion;

            if (_life > 100)
            {
                _life = 100;
            }

            _iuManager.ActualizarColorVida(_life);
            _iuManager.FillAmount_Colorvida(_life / 100f);

        }
    }
}