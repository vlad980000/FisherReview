using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TutorialViev _tutorialViev;

    [SerializeField] private ShopArea _shopArea;

    [SerializeField] private Fishnets _fishnets;

    [SerializeField] private TutorialCamera _tutorialCamera;

    [SerializeField] private FishSpawner _tutorialSpawner;

    [SerializeField] private PlayableDirector  _tutorialCutscene;

    [SerializeField] private FishSpawnBuyer _firstSpawnBuyer;
    [SerializeField] private FishSpawnBuyer _secondSpawnBuyer;
    [SerializeField] private FishSpawnBuyer _thirdSpawnBuyer;

    private List<FishSpawnBuyer> _spawners;

    private Canvas _canvas;

    private TrackerStageOne _trackerStageOne;

    private void Awake()
    {
        _trackerStageOne = _fishnets.GetComponent<TrackerStageOne>();
    }

    private void Start()
    {
        _spawners = new List<FishSpawnBuyer>();

        _spawners.Add(_firstSpawnBuyer);
        _spawners.Add(_secondSpawnBuyer);
        _spawners.Add(_thirdSpawnBuyer);

        _canvas = GetComponent<Canvas>();

        StageOne();
    }

    private void StageOne()
    {
        _tutorialViev.StageOne(_tutorialSpawner.transform);
    }

    private void OnStageOneIsEnded()
    {
        _tutorialViev.StageTwo(_shopArea.SellPoint.transform);
    }

    private void OnStageTwoIsEnded()
    {
        _tutorialViev.StageThree();
        _tutorialCutscene.Play();
    }

    private void OnSpawnerIsReached(FishSpawnBuyer spawner)
    {
        spawner.Animation();
    }

    private void OnEnable()
    {
        _trackerStageOne.StageOneIsEnded += OnStageOneIsEnded;
        _shopArea.StageTwoIsEnded += OnStageTwoIsEnded;
    }

    private void OnDisable()
    {
        _trackerStageOne.StageOneIsEnded -= OnStageOneIsEnded;
        _shopArea.StageTwoIsEnded -= OnStageTwoIsEnded;
    }
}
