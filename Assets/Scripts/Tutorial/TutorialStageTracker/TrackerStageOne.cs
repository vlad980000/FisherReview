using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackerStageOne : MonoBehaviour
{
    [SerializeField] private Fishnets _fishnets;

    public event UnityAction StageOneIsEnded;

    private void OnEnable()
    {
        _fishnets.TutorialStageOneIsEnded += OnStageOneEnded;
    }

    private void OnDisable()
    {
        _fishnets.TutorialStageOneIsEnded -= OnStageOneEnded;
    }

    private void OnStageOneEnded()
    {
        StageOneIsEnded?.Invoke();
        enabled = false;
    }
}
