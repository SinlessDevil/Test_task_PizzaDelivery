using UnityEngine;
using System;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private BicycleCharacter _character;
    [SerializeField] private Joystick _joystick;

    private const float VALUE_SPEED_BY_DEFAULT = 1f; // - speedTransport = 0.075f

    private void Start()
    {
        if (_character == null || _joystick == null) 
            throw new NullReferenceException("Field character or joystick is not assigned!");
    }

    private void FixedUpdate()
    {
        _character.SetSpeed(VALUE_SPEED_BY_DEFAULT + _joystick.Horizontal);
        _character.PedalsRotation(_joystick.Horizontal + 0.2f);
    }
}