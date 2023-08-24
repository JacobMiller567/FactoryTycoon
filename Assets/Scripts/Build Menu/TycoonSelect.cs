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
            build.SpawnBuilding(0);
        }

    }

    public void BuyBallDropper()
    {
        if (stats.PlayerMoney >= 100)
        {
            stats.PlayerMoney -= 100;
            build.tycoonPurchased = true;
            build.SpawnBuilding(1);
        }
    }

    public void BuyDrillMine()
    {
        if (stats.PlayerMoney >= 150)
        {
            stats.PlayerMoney -= 150;
            build.tycoonPurchased = true;
            build.SpawnBuilding(2);
        }

    }


    public void IncreaseLandSize() // Maybe move to a different script?
    {
        if (stats.PlayerMoney >= landUpgrade)
        {
            stats.PlayerMoney -= landUpgrade;
            landUpgrade = landUpgrade * 4;
            land.transform.localScale += new Vector3(1f, 1f, 1f);
            landCostText.text = "Increase Land: $" + landUpgrade.ToString();
        }
    }

}
