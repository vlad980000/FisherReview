using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class TutorialCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float _animationDuration;

    private ShipTracker _shipTracker;

    private Vector3 _deltaPosition;

    private Coroutine _coroutine;


    private void Start()
    {
        _shipTracker = _camera.GetComponent<ShipTracker>();
    }

    public void SetActiveShipTracker()
    {
        _shipTracker.enabled = !_shipTracker.enabled;
    }

    public void Move(GameObject target1)
    {
        _deltaPosition = _shipTracker.DeltaPosition;
        StartCoroutine(MoveToTarget(target1));
    }

    private IEnumerator MoveToTarget(GameObject target)
    {
        float time = 0;
        float progress = 0;

        Vector3 targetPosition = target.transform.position + _deltaPosition ;
        Vector3 startPosition = transform.position;

        while (time < _animationDuration)
        {
            time += Time.deltaTime;
            progress = time / _animationDuration;
            transform.position = Vector3.Lerp(startPosition,targetPosition,progress);

            yield return null;
        }
        yield break;
    }
}
