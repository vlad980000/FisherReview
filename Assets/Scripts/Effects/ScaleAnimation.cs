using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleAnimation;

    [SerializeField] private float _duration;

    private Vector3 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
    }

    public void PlayAnimation()
    {
        StartCoroutine(PLayAnimation());
    }

    private IEnumerator PLayAnimation()
    {

        float expiredSeconds = 0;
        float progress = 0;
        float scale = 0;

        while ( progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _duration;
            scale = _scaleAnimation.Evaluate(progress);
            transform.localScale = new Vector3(scale, scale, scale) + _startScale;
            
            yield return null;
        }
        yield break;
    } 
}
