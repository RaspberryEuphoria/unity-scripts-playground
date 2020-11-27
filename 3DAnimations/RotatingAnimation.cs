using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAnimation : MonoBehaviour
{
    private float animationInterval = 0.01f;
    private float animationSpeed = 1f;
    private bool isAnimationRunning = false;
    private bool _isInPosition = false;
    private IEnumerator coroutine;

    private bool IsInPosition
    {
        get { return _isInPosition; }
        set
        {
            _isInPosition = value;

            gameObject.SendMessage("RotatingAnimationDone", _isInPosition, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Initialize(float _animationSpeed)
    {
        animationSpeed = _animationSpeed;
    }

    public void StartAnimation()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = AnimateRotation(90f);
        StartCoroutine(coroutine);
    }

    private IEnumerator AnimateRotation(float degreeToRotate)
    {
        isAnimationRunning = true;

        Vector3 currentRotation = gameObject.transform.rotation.eulerAngles;
        float currentY = currentRotation.y;
        float targetY = currentY + 90f;

        while (isAnimationRunning)
        {
            currentY += animationSpeed;

            gameObject.transform.eulerAngles = new Vector3(currentRotation.x, currentY, currentRotation.z);

            if (Mathf.Approximately(currentY, targetY))
            {
                IsInPosition = true;
                isAnimationRunning = false;
            }

            yield return new WaitForSeconds(animationInterval);
        }
    }

}

