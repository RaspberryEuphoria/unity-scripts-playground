using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    private PressurePlateBehavior pressurePlateBehavior;
    public GameObject pressurePlateObject;

    void Awake()
    {
        pressurePlateBehavior = pressurePlateObject.GetComponent<PressurePlateBehavior>();
    }

    void OnTriggerEnter()
    {
        pressurePlateBehavior.TogglePlate(true);
    }

    void OnTriggerExit()
    {
        pressurePlateBehavior.TogglePlate(false);
    }
}
