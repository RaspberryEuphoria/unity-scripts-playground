using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private SlidingAnimation _slidingAnimation;
    private bool isActive = false;

    public float animationSpeed = 0.01f;
    public float yPositionWhenDown = 0f;
    public List<GameObject> targetObjects = new List<GameObject>();

    public void Awake()
    {
        _slidingAnimation = gameObject.AddComponent<SlidingAnimation>();
        _slidingAnimation.Initialize(animationSpeed, yPositionWhenDown);
    }

    public void EndAnimation(bool isDown)
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
