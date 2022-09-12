using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GetMoneyPlayerAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [SerializeField] private float _targetY;
    [SerializeField] private float _duration;

    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        PlayAnimation();
    }

    private void Update()
    {
        transform.rotation = GetComponent<Canvas>().worldCamera.transform.rotation;
    }

    public void SetValue(int fishCost)
    {
        _text.text = fishCost.ToString();
    }

    private IEnumerator ChangeColor()
    {
        var waitDurationTime = new WaitForSeconds(_duration);
        var waitOneSecond = new WaitForSeconds(0.2f);

        float normalize = 1;

        yield return waitDurationTime;

        for (int i = 0; i < _duration; i++)
        {
            _canvasGroup.alpha -= normalize / _duration;

            yield return waitOneSecond;
        }

        yield break;
    }

    private void PlayAnimation()
    {
        transform.DOMoveY(transform.position.y + _targetY, _duration);

        StartCoroutine(ChangeColor());
    }
}
