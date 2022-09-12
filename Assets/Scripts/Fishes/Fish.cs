using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fish : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private int _transformsCount;

    private Vector3[] _waypoints;

    private FishSpawner _parentSpawner;

    public Vector3[] Waypoints => _waypoints;

    public int Cost => _cost;

    public void SetSpawner(FishSpawner parentSpawner)
    {
        _parentSpawner = parentSpawner;

        GetTransforms();
    }

    private void GetTransforms()
    {
        _waypoints = new Vector3[_transformsCount];

        for (int i = 0; i < _transformsCount; i++)
        {
            _waypoints[i] = _parentSpawner.GetRandomPoint();
        }
    }
}
