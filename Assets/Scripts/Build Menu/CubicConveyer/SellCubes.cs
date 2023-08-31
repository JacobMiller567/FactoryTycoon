using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCubes : MonoBehaviour
{
    public PlayerStats stats;
    public Cube cube;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            stats.PlayerMoney += cube.SellPrice;
            Destroy(collision.gameObject);  
        }
    }
}
