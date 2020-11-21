using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private VerticalSlidingAnimation _verticalSlidingAnimation;
    private bool isActive = false;
    public float animationSpeed = 0.01f;
    public float yPositionWhenDown = 0;
    public GameObject targetObject;
    public GameObject secondTargetObject;
    public GameObject thirdTargetObject;

    private List<GameObject> targetObjects = new List<GameObject>();

    public void Awake()
    {
        _verticalSlidingAnimation = gameObject.AddComponent<VerticalSlidingAnimation>();
        _verticalSlidingAnimation.Initialize(animationSpeed, yPositionWhenDown);

        targetObjects.Add(targetObject);

        if (secondTargetObject != null)
        {
            targetObjects.Add(secondTargetObject);
        }

        if (thirdTargetObject != null)
        {
            targetObjects.Add(thirdTargetObject);
        }
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
        _verticalSlidingAnimation.StartAnimation(isEntering);
    }
}
