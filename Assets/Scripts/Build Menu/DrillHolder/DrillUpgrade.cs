using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrillUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] rocks;
    [SerializeField] private GameObject button;

    public PlayerStats stats;
    public TycoonManager manage;
    public Drill drill;
    public DrillSpin drillSpin;
    public Transform player;
    public TMP_Text upgradeText;

    private int clickRange = 2;
    public int upgradeCost;
    public bool onPlate = false;


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


    public void UpgradeDrill()
    {
        if (stats.PlayerMoney >= upgradeCost && manage.MaxedLevel == false)
        {
            stats.PlayerMoney -= upgradeCost;
            manage.MachineLevel += 1;
            upgradeCost = upgradeCost * 3;
            drillSpin.speed += 75;
            drill.timer -= 5f;
            drill.sellPrice += 20;

            if (manage.MachineLevel >= 3)
            {
                rocks[0].SetActive(false);
                rocks[1].SetActive(true); // Change ore type
                manage.MaxedLevel = true;
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
