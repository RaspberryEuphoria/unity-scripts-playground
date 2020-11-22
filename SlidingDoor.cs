using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private SlidingAnimation _slidingAnimation;

    [Header("Sliding Animation Settings")]
    public Direction direction;
    [Tooltip("Based on current direction, this field will either set the position on the axis X or Y")]
    public float positionWhenSlided = 0f;
    public float animationSpeed = 0.01f;

    public void Awake()
    {
        _slidingAnimation = gameObject.AddComponent<SlidingAnimation>();
        _slidingAnimation.Initialize(animationSpeed, positionWhenSlided, direction);
    }

    public void ReceiveTrigger(bool isActive)
    {
        _slidingAnimation.StartAnimation(isActive);
    }

}
