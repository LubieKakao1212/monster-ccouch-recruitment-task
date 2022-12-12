using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float maxMovementSpeed = 1f;

    [SerializeField]
    private Rigidbody2D rigid;

    private bool isMouseControll = false;

    void OnEnable()
    {
        var im = InputManager.Instance;

        im.PlayerMoveMouseTriggerRaw += SetMouseControll;
        im.PlayerMoveMousePositionRaw += ProcessMousePosition;

        im.PlayerMoveKeyboardRaw += ProcessKeyboardInput;

    }

    private void OnDisable()
    {
        var im = InputManager.Instance;

        if (im != null)
        {
            im.PlayerMoveMouseTriggerRaw -= SetMouseControll;
            im.PlayerMoveMousePositionRaw -= ProcessMousePosition;

            im.PlayerMoveKeyboardRaw -= ProcessKeyboardInput;
        }
    }

    private void SetMouseControll(bool value)
    {
        isMouseControll = value;
    }

    private void ProcessMousePosition(Vector2 pos)
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(pos);

        var relativeMousePosition = worldMousePosition - transform.position;

        SetMovement(((Vector2)relativeMousePosition).normalized, 1, isMouseControll);
    }

    private void ProcessKeyboardInput(Vector2 input)
    {
        SetMovement(input.normalized, 1, !isMouseControll);
    }

    private void SetMovement(Vector2 direction, float speedRatio, bool doSet)
    {
        if (doSet)
        {
            rigid.velocity = direction * speedRatio * maxMovementSpeed;
        }
    }
}
