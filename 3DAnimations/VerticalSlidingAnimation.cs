using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VerticalSlidingAnimation : MonoBehaviour
{
    private float yPositionWhenUp;
    private bool isAnimationRunning = false;
    private IEnumerator coroutine;
    private bool _isDown = false;
    private float animationInterval = 0.01f;

    public float animationSpeed = 0.01f;
    public float yPositionWhenDown;

    private bool IsDown
    {
        get { return _isDown; }
        set
        {
            _isDown = value;

            EndAnimation(value);
        }
    }

    void Awake()
    {
        yPositionWhenUp = transform.position.y;
        // animationInterval = (transform.localScale.y - yPositionWhenUp) / 5f;
    }

    public abstract void EndAnimation(bool isDown);

    public void StartAnimation(bool movingDown)
    {
        if (coroutine != null)
        {
            IsDown = !movingDown;
            StopCoroutine(coroutine);
        }

        coroutine = AnimateSliding(movingDown);
        StartCoroutine(coroutine);
    }

    private IEnumerator AnimateSliding(bool movingDown)
    {
        isAnimationRunning = true;

        float targetY = movingDown ? yPositionWhenDown : yPositionWhenUp;
        float currentY = transform.position.y;

        while (isAnimationRunning)
        {
            currentY += movingDown ? -animationSpeed : animationSpeed;

            transform.position = new Vector3(transform.position.x, currentY, transform.position.z);

            bool isTooFar = (movingDown && currentY < targetY) || (!movingDown && currentY > targetY);

            if (Mathf.Approximately(currentY, targetY) || isTooFar)
            {
                IsDown = movingDown;
                isAnimationRunning = false;

                if (isTooFar)
                {
                    transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
                }
            }

            yield return new WaitForSeconds(animationInterval);
        }
    }
}

