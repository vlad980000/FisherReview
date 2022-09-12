using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Fish))]
[RequireComponent(typeof(BoxCollider))]
public class FishCatchAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;

    [SerializeField] private float _duration;

    [SerializeField] private ParticleSystem _trail;

    private float _animationTime;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        enabled = false;
    }

    private void Jump(float time)
    {
        transform.position = new Vector3(transform.position.x,_yAnimation.Evaluate(time), transform.position.z);
    }

    private IEnumerator BounseAnimation(Transform startPosition,Transform target)
    {
        enabled = true;

        float time = 0;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition.position,target.position,time);
            Jump(time);
            time += Time.deltaTime / _duration;

            yield return null;
        }
        yield break;
    }

    public void PlayAnimation(Transform startPosition,Transform target)
    {
        _trail.Play();
        StartCoroutine(BounseAnimation(startPosition,target));
    }
}
