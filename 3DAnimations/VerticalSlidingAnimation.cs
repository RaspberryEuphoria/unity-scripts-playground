using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSlidingAnimation : MonoBehaviour
{
    private float yPositionWhenUp;
    private float yPositionWhenDown = 0f;
    private float animationInterval = 0.01f;
    private float animationSpeed = 0.01f;
    private bool isAnimationRunning = false;
    private bool _isDown = false;
    private IEnumerator coroutine;

    private bool IsDown
    {
        get { return _isDown; }
        set
        {
            _isDown = value;

            gameObject.SendMessage("EndAnimation", value, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Awake()
    {
        yPositionWhenUp = gameObject.transform.localPosition.y;
    }

    public void Initialize(float _animationSpeed, float _yPositionWhenDown)
    {
        animationSpeed = _animationSpeed;
        yPositionWhenDown = _yPositionWhenDown;
    }

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

        float currentY = gameObject.transform.localPosition.y;
        float targetY = movingDown ? yPositionWhenDown : yPositionWhenUp;

        while (isAnimationRunning)
        {
            Vector3 currentPosition = gameObject.transform.localPosition;
            currentY += movingDown ? -animationSpeed : animationSpeed;

            gameObject.transform.localPosition = new Vector3(currentPosition.x, currentY, currentPosition.z);

            bool isTooFar = (movingDown && currentY < targetY) || (!movingDown && currentY > targetY);

            if (Mathf.Approximately(currentY, targetY) || isTooFar)
            {
                IsDown = movingDown;
                isAnimationRunning = false;

                if (isTooFar)
                {
                    gameObject.transform.localPosition = new Vector3(currentPosition.x, targetY, currentPosition.z);
                }
            }

            yield return new WaitForSeconds(animationInterval);
        }
    }
}

