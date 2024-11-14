using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputController : MonoBehaviour
{
    public UnityAction<Vector2> OnPositionEvent;
    public UnityAction<bool> OnClickEvent;
    public Vector2 MousePosition{get; private set;}
    private PlayerInput Input;
    private Camera mainCam;

    private void Awake()
    {
        Input = new PlayerInput();
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        Input.Player.Position.performed += PlayerPosition;
        Input.Player.Position.canceled += PlayerPosition;
        Input.Player.Click.performed += PlayerClick;
        Input.Player.Click.canceled += PlayerClick;

        Input.Player.Enable();
    }

    private void OnDisable()
    {
        Input.Player.Disable();
    }

    private void PlayerPosition(InputAction.CallbackContext context)
    {
        Vector2 newPositionValue = context.ReadValue<Vector2>();
        Vector2 worldPos = mainCam.ScreenToWorldPoint(newPositionValue);
        MousePosition = worldPos;
    }

    private void PlayerClick(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        bool isPressed = value > 0.5f;
        OnClickEvent?.Invoke(isPressed);
    }
}
