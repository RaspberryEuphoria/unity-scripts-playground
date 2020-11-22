using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDoor : MonoBehaviour
{
    private SlidingAnimation _slidingAnimation;

    public float animationSpeed = 0.01f;
    public float yPositionWhenDown = 0f;
    public Direction direction;

    public void Awake()
    {
        _slidingAnimation = gameObject.AddComponent<SlidingAnimation>();
        _slidingAnimation.Initialize(animationSpeed, yPositionWhenDown, direction);
    }

    public void Trigger(bool isMovingDown)
    {
        _slidingAnimation.StartAnimation(isMovingDown);
    }

}
