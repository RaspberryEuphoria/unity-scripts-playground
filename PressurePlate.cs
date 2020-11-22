using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private SlidingAnimation _slidingAnimation;
    private bool isActive = false;

    [Header("Sliding Animation Settings")]
    public float animationSpeed = 0.01f;
    public float yPositionWhenSlidedDown = 0f;

    [Header("Trigger Settings")]
    [Tooltip("These objects will be trigger when the pressure plate is activated")]
    public List<GameObject> targetObjects = new List<GameObject>();

    public void Awake()
    {
        _slidingAnimation = gameObject.AddComponent<SlidingAnimation>();
        _slidingAnimation.Initialize(animationSpeed, yPositionWhenSlidedDown, Direction.Down);
    }

    public void SlidingAnimationDone(bool isDown)
    {
        isActive = isDown;

        foreach (GameObject target in targetObjects)
        {
            target.SendMessage("Trigger", isActive);
        }
    }

    public void Toggle(bool isEntering)
    {
        _slidingAnimation.StartAnimation(isEntering);
    }
}
