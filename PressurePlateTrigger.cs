using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    private PressurePlate pressurePlate;
    public GameObject pressurePlateObject;

    void Awake()
    {
        pressurePlate = pressurePlateObject.GetComponent<PressurePlate>();
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
