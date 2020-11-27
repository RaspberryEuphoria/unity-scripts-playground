using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    private RotatingAnimation _rotatingAnimation;
    private bool isMoving = false;

    [Header("Rotating Animation Settings")]
    public float animationSpeed = 1f;

    public void Awake()
    {
        _rotatingAnimation = gameObject.AddComponent<RotatingAnimation>();
        _rotatingAnimation.Initialize(animationSpeed);
    }

    public void ReceiveTrigger(bool isActive)
    {
        Debug.Log(isActive);

        if (!isMoving && isActive)
        {
            isMoving = true;
            _rotatingAnimation.StartAnimation();
        }
    }

    public void RotatingAnimationDone(bool isRotated)
    {
        isMoving = false;
    }

}
