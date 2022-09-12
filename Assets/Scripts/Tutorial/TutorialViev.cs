using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialViev : MonoBehaviour
{
    [SerializeField] ArrowAnimations _arrowPointer;
    [SerializeField] TutorialCircleShipAnimation _circleShipAnimation;

    private ArrowAnimations _currentArrowAnimation;
    private TutorialCircleShipAnimation _currentTutorialCircleShipAnimation;

    public void StageOne(Transform target)
    {
        _currentArrowAnimation = Instantiate(_arrowPointer, target);
        _currentTutorialCircleShipAnimation = Instantiate(_circleShipAnimation, target);
    }

    public void StageTwo(Transform target)
    {
        _currentArrowAnimation.transform.position = target.position;
        _currentTutorialCircleShipAnimation.GetComponent<TutorialShipScaleAnimation>().PlayAnimation();
    }

    public void StageThree()
    {
        _currentArrowAnimation.gameObject.SetActive(false);
    }
}
