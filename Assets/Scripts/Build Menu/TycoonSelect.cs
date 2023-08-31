using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TycoonSelect : MonoBehaviour
{
    public BuildMenu build;
    public PlayerStats stats;
    public int landUpgrade;
    public GameObject land;
    public TMP_Text landCostText;

/*
    public void BuyTower(int num, int cost)
    {
        if (stats.PlayerMoney >= cost)
        {
            stats.PlayerMoney -= cost;
            build.SpawnBuilding(num);
        }

    }
*/

    public void BuyCubeFactory()
    {
        if (stats.PlayerMoney >= 75)
        {
            stats.PlayerMoney -= 75;
            build.tycoonPurchased = true;
            build.SpawnBuilding(0, 0f, 0f, 0f); // Building type and spawning offset
          //  StartCoroutine(Spawn(0));
        }
    }

    public void BuyBallDropper()
    {
        if (stats.PlayerMoney >= 100)
        {
            stats.PlayerMoney -= 100;
            build.tycoonPurchased = true;
           // build.SpawnBuilding(1,-84.319f, 0f, 90f);
            build.SpawnBuilding(1, 0f, 0.4f, 0f); // Building type and spawning offset
        //    StartCoroutine(Spawn(1));
        }
    }

    public void BuyDrillMine()
    {
        if (stats.PlayerMoney >= 150)
        {
            stats.PlayerMoney -= 150;
            build.tycoonPurchased = true;
           // build.SpawnBuilding(2, -180f, -25.729f, 0f);
           build.SpawnBuilding(2, 0f, 1.5f, 0f); // Building type and spawning offset
         //   StartCoroutine(Spawn(2));
        }

    }


    public void BuyCubicConveyor() // Maybe move to a different script?
    {
        if (stats.PlayerMoney >= 250)
        {
            stats.PlayerMoney -= 250;
            build.tycoonPurchased = true;
            build.SpawnBuilding(3, 0f, .9f, 0f); // Building type and spawning offset
        }
    }


    IEnumerator Spawn(int num)
    {
        yield return new WaitForSeconds(.5f);
        //build.SpawnBuilding(num);

    }

}
