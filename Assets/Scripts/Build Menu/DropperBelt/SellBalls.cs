using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBalls : MonoBehaviour
{
    public PlayerStats stats;
    public Cube ball;
    public Color yellow;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            /*
            if (collision.gameObject.GetComponent<Renderer>().material.color == yellow)
            {
                Debug.Log("YELLOW!!!");
                ball.SellPrice += 100;
            }
            */
            stats.PlayerMoney += ball.SellPrice;

            Destroy(collision.gameObject);
            
        }
    }
}
