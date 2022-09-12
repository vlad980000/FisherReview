using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialCircleShipAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _duration;
    private Quaternion _yRotation;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _coroutine;
    private void Start()
    {
        _yRotation = Quaternion.AngleAxis(1,new Vector3(0, 0, 1));
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.DOFade(0.4f,0.6f).SetLoops(-1,LoopType.Yoyo);
    }

    private void Update()
    {
        transform.rotation *= _yRotation;
    }
}
