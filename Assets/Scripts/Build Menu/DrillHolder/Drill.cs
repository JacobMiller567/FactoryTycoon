using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public float timer;
    public bool canEarn;
    public int sellPrice;
    public PlayerStats player;

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        //player = GameObject.Find("Player").transform;
    }

    

    // Update is called once per frame
    void Update()
    {

        // If player exists then attach player stats game component to prefab money farm!


        if (canEarn)
        {
            StartCoroutine(Money());
        }     
    }

    IEnumerator Money()
    {
        canEarn = false;
        yield return new WaitForSeconds(timer);
        player.PlayerMoney += sellPrice;
        canEarn = true;
    }
}
