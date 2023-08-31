using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicPressurePlate : MonoBehaviour
{
    public UpgradeCubicConveyor cubic;

    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            cubic.onPlate = true;
           // Debug.Log("Pressed!");
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            cubic.onPlate = false;
           // Debug.Log("Unpressed!");
        }
    }
}
