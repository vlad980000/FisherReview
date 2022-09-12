using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fishnets : MonoBehaviour
{
    [SerializeField] private Fishnet[] _fishnets;

    [SerializeField] private Player _player;

    [SerializeField] private float _scipCachTime;

    private Coroutine _coroutine;

    private List<Fish> _fishList;

    public event UnityAction<int> GivesFish;

    public event UnityAction TutorialStageOneIsEnded;

    private void Awake()
    {
        AssignsNumber();
    }

    private void Start()
    {
        _fishList = new List<Fish> ();
    }

    private void AssignsNumber()
    {
        for (int i = 0; i < _fishnets.Length; i++)
        {
            _fishnets[i].Number = i;
        }
    }

    private IEnumerator GivesCatchedFishes()
    {
        var scipTime = new WaitForSeconds(_scipCachTime);

        for (int i = _fishList.Count - 1 ; i >= 0; i--)
        {
            _player.AddFish(_fishList[i]);
            _fishList[i].GetComponent<FishMovement>().StopMove();
            _fishList[i].GetComponent<FishCatchAnimation>().PlayAnimation(_fishList[i].transform, _player.transform);
            _player.GetComponent<ScaleAnimation>().PlayAnimation();
            _fishList.Remove(_fishList[i]);
            GivesFish?.Invoke(_fishList[i].Cost);

            yield return scipTime;
        }
        _coroutine = null;
        yield break;
    }

    private void OnCircleIsOpened()
    {
        if(_coroutine != null)
            return;

        _coroutine = StartCoroutine(GivesCatchedFishes());
    }

    private void OnCircleIsClosed(Fishnet fishnet)
    {
        for (int i = 0; i < fishnet.Number + 1 ; i++)
        {
            Ray ray = new Ray(fishnet.transform.position, _fishnets[i].transform.position - fishnet.transform.position);
            RaycastHit hit;

            _fishnets[i].StartEffect();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Fish fish))
                {
                    TutorialStageOneIsEnded?.Invoke();
                    if (_fishList.Count <= _player.Capacity)
                    {
                        fish.GetComponent<BoxCollider>().enabled = false;
                        _fishList.Add(fish);
                        fish.GetComponentInParent<FishSpawner>().DeleteFish(fish);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        _player.CircleIsClosed += OnCircleIsClosed;
        _player.CircleIsOpened += OnCircleIsOpened; 
    }

    private void OnDisable()
    {
        _player.CircleIsClosed -= OnCircleIsClosed;
        _player.CircleIsOpened -= OnCircleIsOpened;
    }
}
