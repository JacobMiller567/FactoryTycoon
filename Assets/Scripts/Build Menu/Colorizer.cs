using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    
    //Material m_Material;
    public Color yellow;
    public Cube ball;

   // void OnCollisionEnter(Collision collision)
    void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = yellow;
            // USE this when in build mode!
            //ball.SellPrice = ball.SellPrice * 2; //TEST // Bug: When using prefabs in test mode
            
            ball.SellPrice = 4; // Temp fix
            Debug.Log("YELLOW TEST");

        }
    }
    
}
