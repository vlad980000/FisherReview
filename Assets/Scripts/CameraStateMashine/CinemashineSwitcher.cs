using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemashineSwitcher : MonoBehaviour
{

    [SerializeField] private ShipMovement _shipMovement;

    [SerializeField] private CinemachineVirtualCamera _idleCamera;
    [SerializeField] private CinemachineVirtualCamera _moveCamera;

    [SerializeField] private int _highPriority;
    [SerializeField] private int _lowPriority;

    private bool _isMoving;

    private void Update()
    {
        _isMoving = _shipMovement.TakeIsMoving();

        if( _isMoving == true)
        {
            _moveCamera.Priority = _highPriority;
            _idleCamera.Priority = _lowPriority;
        }
        else if( _isMoving == false)
        {
            _moveCamera.Priority = _highPriority;
            _idleCamera.Priority = _lowPriority;
        }
    }
}
