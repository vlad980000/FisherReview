using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ShopArea : MonoBehaviour
{
    [SerializeField] GameObject _sellPoint;

    [SerializeField] private Player _player;

    [SerializeField] private Money _moneyPrefub;

    [SerializeField] private Camera _camera;
    public GameObject SellPoint => _sellPoint;

    public event UnityAction StageTwoIsEnded;

    private BoxCollider _boxCollider;
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _player.FishIsSold += OnSellFish;
    }

    private void OnDisable()
    {
        _player.FishIsSold -= OnSellFish;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            player.SellFish(transform);
        }
        StageTwoIsEnded?.Invoke();
    }

    private void OnSellFish()
    {
        var prefub = Instantiate(_moneyPrefub, transform);
        prefub.SetCamera(_camera);
    }
}
