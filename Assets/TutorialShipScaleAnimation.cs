using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShipScaleAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleAnimation;

    [SerializeField] private float _duration;

    private RectTransform _rectTransform;
    private RectTransform _startScale;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startScale = _rectTransform;
    }

    public void PlayAnimation()
    {
        StartCoroutine(PLayAnimation());
    }

    private IEnumerator PLayAnimation()
    {
        float expiredSeconds = 0;
        float progress = 0;
        float scale;
        float value;
        
        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _duration;
            scale = _scaleAnimation.Evaluate(progress);
            value = transform.localScale.x - scale;
            value = Mathf.Clamp(value,0,2);
            transform.localScale = new Vector3(value, value, value);
            
            yield return null;
        }
        yield break;
    }
}
