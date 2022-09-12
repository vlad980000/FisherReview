using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFishCountInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TMP_Text _textMesh;

    private Vector3 _deltaPosition;

    private void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
        SetValue();
        _deltaPosition = transform.position - _player.transform.position;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _deltaPosition;
    }

    private void SetValue()
    {
        if (_player.FishCount == _player.Capacity)
        {
            _textMesh.faceColor = Color.red;
            _textMesh.text = "full";
        }
        else
        {
            _textMesh.faceColor = Color.white;
            _textMesh.text = $"{_player.FishCount}/{_player.Capacity}";
        }
    }

    private void OnChangeCount()
    {
        SetValue();
    }

    private void OnEnable()
    {
        _player.FishCountIsCahnged += OnChangeCount;
    }

    private void OnDisable()
    {
        _player.FishCountIsCahnged -= OnChangeCount;
    }
}
