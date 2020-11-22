using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    private PressurePlate pressurePlate;

    void Awake()
    {
        pressurePlate = transform.parent.gameObject.GetComponent<PressurePlate>();
    }

    void OnTriggerEnter()
    {
        pressurePlate.Toggle(true);
    }

    void OnTriggerExit()
    {
        pressurePlate.Toggle(false);
    }
}
