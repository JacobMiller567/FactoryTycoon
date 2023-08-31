using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    public Transform conveyorBelt;
    private bool onBelt;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ConveyorBelt") {
            transform.position = other.transform.position;
            onBelt = true;
            Debug.Log("On Belt!");


        }
    }

    void Update() 
    {
        if (onBelt)
        {
            transform.position += conveyorBelt.forward * Time.deltaTime;
        }
        //transform.position += new Vector3(0f, 0f, .5f);
    }
}
