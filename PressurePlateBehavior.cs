using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehavior : VerticalSlidingAnimation
{
    private bool isActive = false;

    public GameObject targetObject;

    public override void EndAnimation(bool isDown) {
        isActive = isDown;

        targetObject.SendMessage("Trigger", isActive);
    }

    public void TogglePlate(bool isEntering) {
        StartAnimation(isEntering);
    }
}
