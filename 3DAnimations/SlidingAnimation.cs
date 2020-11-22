﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Left, Right, Up, Down }

public class SlidingAnimation : MonoBehaviour
{
    private int axis;
    private float initialAxisValue;
    private float targetAxisValue = 0f;
    private float animationInterval = 0.01f;
    private float animationSpeed = 0.01f;
    private bool isAnimationRunning = false;
    private bool _isInPosition = false;
    private Direction direction;
    private IEnumerator coroutine;

    private bool IsInPosition
    {
        get { return _isInPosition; }
        set
        {
            _isInPosition = value;

            gameObject.SendMessage("SlidingAnimationDone", _isInPosition, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Initialize(float _animationSpeed, float _targetAxisValue, Direction _direction = Direction.Down)
    {
        animationSpeed = _animationSpeed;
        targetAxisValue = _targetAxisValue;
        direction = _direction;

        axis = getAxisByDirection(direction);
        initialAxisValue = gameObject.transform.localPosition[axis];
    }

    public void StartAnimation(bool movingToDirection)
    {
        if (coroutine != null)
        {
            IsInPosition = !movingToDirection;
            StopCoroutine(coroutine);
        }

        coroutine = AnimateSliding(movingToDirection);
        StartCoroutine(coroutine);
    }

    private int getAxisByDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
            case Direction.Right:
                return 0;
            case Direction.Up:
            case Direction.Down:
            default:
                return 1;
        }
    }

    private IEnumerator AnimateSliding(bool movingToDirection)
    {
        isAnimationRunning = true;

        Vector3 currentPosition = gameObject.transform.localPosition;

        float axisValue = currentPosition[axis];
        float targetValue = movingToDirection ? targetAxisValue : initialAxisValue;

        while (isAnimationRunning)
        {
            axisValue = updateAxisValue(movingToDirection, axisValue);
            gameObject.transform.localPosition = updatePosition(currentPosition, axisValue);

            bool isTooFar = checkIfTooFar(movingToDirection, axisValue, targetValue);

            if (Mathf.Approximately(axisValue, targetValue) || isTooFar)
            {
                IsInPosition = movingToDirection;
                isAnimationRunning = false;

                if (isTooFar)
                {
                    gameObject.transform.localPosition = updatePosition(currentPosition, targetValue);
                }
            }

            yield return new WaitForSeconds(animationInterval);
        }
    }

    private float updateAxisValue(bool movingToDirection, float axisValue)
    {
        float speed = movingToDirection ? animationSpeed : -animationSpeed;

        switch (direction)
        {
            case Direction.Right:
            case Direction.Up:
                axisValue += speed;
                break;
            case Direction.Left:
            case Direction.Down:
            default:
                axisValue -= speed;
                break;
        }

        return axisValue;
    }

    private Vector3 updatePosition(Vector3 position, float axisValue)
    {
        if (axis == 0)
        {
            return new Vector3(axisValue, position.y, position.z);
        }

        return new Vector3(position.x, axisValue, position.z);
    }

    private bool checkIfTooFar(bool movingToDirection, float axisValue, float targetValue)
    {
        if (movingToDirection)
        {
            switch (direction)
            {
                case Direction.Right:
                case Direction.Up:
                    return axisValue > targetValue;
                case Direction.Left:
                case Direction.Down:
                default:
                    return axisValue < targetValue;
            }
        }

        switch (direction)
        {
            case Direction.Right:
            case Direction.Up:
                return axisValue < targetValue;
            case Direction.Left:
            case Direction.Down:
            default:
                return axisValue > targetValue;
        }
    }
}

