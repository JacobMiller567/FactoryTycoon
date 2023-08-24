using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate2 : MonoBehaviour
{
    public UpgradeDropper dropper;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            dropper.onPlate = true;
            Debug.Log("Pressed!");
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            dropper.onPlate = false;
            Debug.Log("Unpressed!");
        }
    }
}
