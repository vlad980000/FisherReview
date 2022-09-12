using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentCostInput : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentCost;

    [SerializeField]private FishSpawnBuyer _spawnBuyer;

    private void Start()
    {
        _currentCost.text = _spawnBuyer.CurrentCost.ToString();
    }

    private void OnCurrentCostChanged()
    {
        _currentCost.text = _spawnBuyer.CurrentCost.ToString();
    }

    private void OnEnable()
    {
        _spawnBuyer.CurrentCostIsCanged += OnCurrentCostChanged;
    }

    private void OnDisable()
    {
        _spawnBuyer.CurrentCostIsCanged -= OnCurrentCostChanged;
    }
}
