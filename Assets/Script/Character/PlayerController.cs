using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    PlayerInput _playerInput;
    public InputActionAsset actions;

    PlayerInputActions _inputActions;
    
    public Vector2 inputVector;

    public delegate void PressInputEvent();
    public PressInputEvent PressSprint;

    public delegate void ReleaseInputEvent();
    public ReleaseInputEvent ReleaseSprint;

    void Awake()
    {
        //?
        //gameObject.layer = 7;
    }

    void Start()
    {
        _playerInput = gameObject.AddComponent<PlayerInput>();
        actions.Enable();
        _playerInput.actions = actions;

        //Player Input Actions C#
        _inputActions = new PlayerInputActions();

        _inputActions.Enable();
        _inputActions.Player.Sprint.performed += x => SprintPressed();
        _inputActions.Player.Sprint.canceled += x => SprintReleased();
    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void SprintPressed()
    {
        PressSprint.Invoke();
    }

    void SprintReleased()
    {
        ReleaseSprint.Invoke();
    }

    void LateUpdate()
    {

    }
        
    private void Update()
    {
    }
}


