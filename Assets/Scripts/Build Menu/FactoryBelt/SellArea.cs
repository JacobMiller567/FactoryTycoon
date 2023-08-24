using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellArea : MonoBehaviour
{
    public PlayerStats stats;
    public Cube cube;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            stats.PlayerMoney += cube.SellPrice;
            return;
        }
    }

    
}
