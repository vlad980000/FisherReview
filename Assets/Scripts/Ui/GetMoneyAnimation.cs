using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoneyAnimation : MonoBehaviour
{
    [SerializeField] private GetMoneyPlayerAnimation _prefab;

    [SerializeField] private Player _player;

    [SerializeField] private float _spawnRadius;

    [SerializeField] private int _minY;
    [SerializeField] private int _maxY;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x + Random.insideUnitSphere.x * _spawnRadius, transform.position.y + Random.Range(_minY, _maxY), transform.position.z);
    }

    private void OnFishCached(int fishCost)
    {
        GetMoneyPlayerAnimation prefub = Instantiate(_prefab, GetRandomPosition(), Quaternion.LookRotation(_camera.transform.position), transform);
        prefub.SetValue(fishCost);
    }

    private void OnEnable()
    {
        _player.FishIsAdded += OnFishCached;
    }

    private void OnDisable()
    {
        _player.FishIsAdded -= OnFishCached;
    }
}
