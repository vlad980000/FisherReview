using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _deltaPosition;

    public Vector3 DeltaPosition => _deltaPosition;

    private void Start()
    {
        _deltaPosition = transform.position - _player.transform.position;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _deltaPosition;
    }
}
