using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimations : MonoBehaviour
{
    [SerializeField] AnimationCurve _yAnimation;

    [SerializeField] float _duration;

    private float _expiredTime = 0;

    private void Update()
    {
        _expiredTime += Time.deltaTime;

        if (_expiredTime > _duration)
            _expiredTime = 0;

        float progress = _expiredTime / _duration;

        transform.position = new Vector3(transform.position.x, _yAnimation.Evaluate(progress), transform.position.z);
    }
}
