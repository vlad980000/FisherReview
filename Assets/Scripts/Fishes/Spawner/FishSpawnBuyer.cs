using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class FishSpawnBuyer : MonoBehaviour
{
    [SerializeField] FishSpawner _prefub;

    [SerializeField] int _cost;

    [SerializeField] CurrentCostInput _currentCostInput;

    [SerializeField] float _targetScale;
    [SerializeField] float _scaleAnimationTime;

    private BoxCollider _boxCollider;

    private int _currentCost;

    private FishSpawner _spawner;

    public float ScaleAnimationTime => _scaleAnimationTime;
    public int CurrentCost => _currentCost;

    public event UnityAction CurrentCostIsCanged;

    public event UnityAction EnabledIsChanged;

    private void Awake()
    {
        _spawner = Instantiate(_prefub, transform);
        _spawner.enabled = false;
        _currentCostInput.enabled = false;
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _currentCost = _cost;
        transform.localScale = Vector3.zero;
    }

    public void Animation()
    {
        _currentCostInput.enabled = true;
        transform.DOScale(_targetScale, _scaleAnimationTime);
        EnabledIsChanged?.Invoke();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            if(player.Money != 0)
            {
                StartCoroutine(ChangeCurrentCost(player.Money));
                player.RemoveMoney();
            }
            else
            {
                return;
            }
        }
    }

    private IEnumerator ChangeCurrentCost(int money)
    {
        var waitHalthSecond = new WaitForSeconds(0.5f);

        int one = 1;

        for (int i = 0; i < money; i++)
        {
            _currentCost -= one;

            CurrentCostIsCanged?.Invoke();

            yield return waitHalthSecond;
        }
        yield break;
    }
}
