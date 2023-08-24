using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public UpgradeMachine machine;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            machine.onPlate = true;
            Debug.Log("Pressed!");
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            machine.onPlate = false;
            Debug.Log("Unpressed!");
        }
    }
}
