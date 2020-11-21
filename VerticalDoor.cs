using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    private VerticalSlidingAnimation _verticalSlidingAnimation;

    public float animationSpeed = 0.01f;
    public float yPositionWhenDown = 0;

    public void Awake()
    {
        _verticalSlidingAnimation = gameObject.AddComponent<VerticalSlidingAnimation>();
        _verticalSlidingAnimation.Initialize(animationSpeed, yPositionWhenDown);
    }

    public void Trigger(bool isMovingDown)
    {
        _verticalSlidingAnimation.StartAnimation(isMovingDown);
    }

}
