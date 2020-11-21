using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSlidingAnimation : MonoBehaviour
{
    private float yPositionWhenUp;
    private float yPositionWhenDown = 0;
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
        yPositionWhenUp = gameObject.transform.position.y;
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

        float targetY = movingDown ? yPositionWhenDown : yPositionWhenUp;
        float currentY = gameObject.transform.position.y;

        while (isAnimationRunning)
        {
            currentY += movingDown ? -animationSpeed : animationSpeed;

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, currentY, gameObject.transform.position.z);

            bool isTooFar = (movingDown && currentY < targetY) || (!movingDown && currentY > targetY);

            if (Mathf.Approximately(currentY, targetY) || isTooFar)
            {
                IsDown = movingDown;
                isAnimationRunning = false;

                if (isTooFar)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, targetY, gameObject.transform.position.z);
                }
            }

            yield return new WaitForSeconds(animationInterval);
        }
    }
}

