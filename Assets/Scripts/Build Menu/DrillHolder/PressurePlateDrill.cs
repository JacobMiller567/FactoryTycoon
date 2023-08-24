using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDrill : MonoBehaviour
{
    public DrillUpgrade drill;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            drill.onPlate = true;
            Debug.Log("Pressed!");
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            drill.onPlate = false;
            Debug.Log("Unpressed!");
        }
    }
}
