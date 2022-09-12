using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float _multiplierCameraPositionY;
    [SerializeField] private float _animationTime;

    private Vector3 _targetDirection;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetDirection = _camera.transform.position - transform.position;
        _targetPosition = _targetDirection / _animationTime;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(_targetPosition, _animationTime));
        sequence.Append(transform.DOMoveY(_camera.transform.position.y * _multiplierCameraPositionY, _animationTime));
    }

    private void Update()
    {
        if(transform.position.y >= _camera.transform.position.y * _multiplierCameraPositionY)
            Destroy(this.gameObject);
    }

    public void SetCamera(Camera camera)
    {
        _camera = camera;
    }
}
