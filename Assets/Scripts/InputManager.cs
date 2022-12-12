using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public event Action<Vector2> PlayerMoveKeyboardRaw;

    public event Action<bool> PlayerMoveMouseTriggerRaw;
    public event Action<Vector2> PlayerMoveMousePositionRaw;

    private InputActions input;

    private void Awake()
    {
        Assert.IsNull(Instance, "There can only be one InputManager");
        Instance = this;

        input = new InputActions();

        input.PlayerKeyboard.Move.performed += (evnt) => PlayerMoveKeyboardRaw?.Invoke(evnt.ReadValue<Vector2>());
        input.PlayerKeyboard.Move.canceled += (evnt) => PlayerMoveKeyboardRaw?.Invoke(Vector2.zero);

        input.PlayerMouse.MouseMove.started += (evnt) => PlayerMoveMouseTriggerRaw?.Invoke(true);
        input.PlayerMouse.MouseMove.canceled += (evnt) => PlayerMoveMouseTriggerRaw?.Invoke(false);

        input.PlayerMouse.MousePosition.performed += (evnt) => PlayerMoveMousePositionRaw?.Invoke(evnt.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
