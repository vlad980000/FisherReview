using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ShipMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private List<Fish> _catch;

    [SerializeField] private int _capacity;

    [SerializeField] private float _soldFishDelay;

    private ShipMovement _shipMovement;

    private BoxCollider _collider;

    private int _money;

    public int FishCount => _catch.Count;
    public int Capacity => _capacity;
    public int Money => _money;

    public event UnityAction<Fishnet> CircleIsClosed;

    public event UnityAction FishCountIsCahnged;

    public event UnityAction<int> FishIsAdded;

    public event UnityAction FishIsSold;

    public event UnityAction CircleIsOpened;

    private void Start()
    {
        _money = 0;
        _collider = GetComponent<BoxCollider>();
        _catch = new List<Fish>(_capacity);
    }

    public void AddFish(Fish fish)
    {
        if (_catch.Count < _capacity)
        {
            _catch.Add(fish);
            FishIsAdded?.Invoke(fish.Cost);
            FishCountIsCahnged?.Invoke();
        }
        else
        {
            return;
        }
    }

    public void SellFish(Transform target)
    {
        if (_catch.Count != 0)
            StartCoroutine(DelaySoldFish(target));
        else
            return;
    }

    public void SetActiveCollider(bool active)
    {
        _collider.enabled = active;
    }

    public void RemoveMoney()
    {
        _money = 0;
    }

    private void AddMoney(int money)
    {
        _money += money;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<Fishnet>(out Fishnet fishnet))
        {
            CircleIsClosed?.Invoke(fishnet);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Fishnet>(out Fishnet fishnet))
        {
            CircleIsOpened?.Invoke();
        }
            
    }

    private IEnumerator DelaySoldFish(Transform target)
    {
        var scipTime = new WaitForSeconds(_soldFishDelay);

        for (int i = 0; i < _catch.Count; i++)
        {
            if(_catch[i] != null)
            {
                _catch[i].enabled = true;
                _catch[i].GetComponent<ScaleAnimation>().PlayAnimation();
                _catch[i].GetComponent<FishCatchAnimation>().PlayAnimation(transform, target);
                AddMoney(_catch[i].Cost);
                _catch[i] = null;
                FishIsSold?.Invoke();
            }
            yield return scipTime;
        }
        _catch.Clear();
        FishCountIsCahnged?.Invoke();

        yield break;
    }
}
