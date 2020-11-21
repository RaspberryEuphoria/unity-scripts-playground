using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private VerticalSlidingAnimation _verticalSlidingAnimation;
    private bool isActive = false;

    public GameObject targetObject;
    public float animationSpeed = 0.01f;
    public float yPositionWhenDown = 0;

    public void Awake()
    {
        _verticalSlidingAnimation = gameObject.AddComponent<VerticalSlidingAnimation>();
        _verticalSlidingAnimation.Initialize(animationSpeed, yPositionWhenDown);
    }

    public void EndAnimation(bool isDown)
    {
        isActive = isDown;

        targetObject.SendMessage("Trigger", isActive);
    }

    public void Toggle(bool isEntering)
    {
        _verticalSlidingAnimation.StartAnimation(isEntering);
    }
}
