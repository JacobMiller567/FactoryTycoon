using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCubicConveyor : MonoBehaviour
{
    public bool onPlate = false;
    public int upgradeCost;
    public Transform player;
    [SerializeField] private GameObject button;
    //[SerializeField] private GameObject[] droppers;

    public ConveyerSpawn spawn;
    public PlayerStats stats;
    public TycoonManager manage;
    public TMP_Text upgradeText;


     void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        player = GameObject.Find("Player").transform;
    }


    public void Update()
    {
        if (onPlate)
        {
            button.SetActive(true);

            if (manage.MaxedLevel == true)
            {
                upgradeText.text = "Upgrade: Maxed";
            }
            else
            {
                upgradeText.text = "Upgrade: $" + upgradeCost;
            }
        }
        else
        {
            button.SetActive(false);
        }
    }


    public void UpgradeConveyor()
    {
        if (stats.PlayerMoney >= upgradeCost && manage.MaxedLevel == false)
        {
            stats.PlayerMoney -= upgradeCost;
            manage.MachineLevel += 1;
            upgradeCost = upgradeCost * 2;
            spawn.speed -= 3f;

            if (manage.MachineLevel >= 3)
            {
                manage.MaxedLevel = true;
                // Add: Increase speed of cubes from 2 to 4
            }
        }
        else if (manage.MaxedLevel == true) 
        {
            Debug.Log("Maxed Level!");
        }
        else
        {
            Debug.Log("Can't Afford Upgrade");
        }

    }
    
}
