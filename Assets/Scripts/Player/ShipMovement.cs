using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private Rigidbody _rigidbody;

    private bool _isMoving;

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed , _rigidbody.velocity.y, _joystick.Vertical * _speed );

        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            _isMoving = true;
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        else
        {
            _isMoving = false;
        }
    }
    
    public bool TakeIsMoving()
    {
        return _isMoving;
    }
}
