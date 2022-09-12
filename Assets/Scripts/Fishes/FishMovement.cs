using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Fish))]
public class FishMovement : MonoBehaviour
{
    [SerializeField] private float _timeToTarget;

    private Fish _fish;

    private Tween _move;

    private void Start()
    {
        _fish = GetComponent<Fish>();

        Move();
    }

    private void Move()
    {
        _move = transform.DOPath(_fish.Waypoints, _timeToTarget, PathType.CatmullRom).SetOptions(true).SetLookAt(0.01f);

        _move.SetLoops(-1);
    }

    public void StopMove()
    {
        _move.Pause();
    }
}
