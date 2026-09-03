using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction _moverAccion;
    [SerializeField] private InputAction _SaltarAccion;

    [SerializeField] private IUManager _iuManager;

    public Vector2 ValordeMovimiento { get; private set; }
    public bool estaSaltando { get; private set; }


    void Awake()
    {
        _moverAccion = InputSystem.actions.FindAction("Move");
        _SaltarAccion = InputSystem.actions.FindAction("Jump");

        Physics.gravity = new Vector3(0f, -70f, 0f);
    }

    void Update()
    {
        ValordeMovimiento = _moverAccion.ReadValue<Vector2>();
        estaSaltando = _SaltarAccion.IsPressed();
    }

 

  
}