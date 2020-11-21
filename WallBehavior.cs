using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : VerticalSlidingAnimation
{

    public override void EndAnimation(bool _)
    {
    }

    public void Trigger(bool isMovingDown) {
        StartAnimation(isMovingDown);
    }

}
