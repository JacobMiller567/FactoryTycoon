using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMachine : MonoBehaviour
{
    private int clickRange = 2;
    public int upgradeCost;
    public bool onPlate = false;
    public Transform player;
    [SerializeField] private GameObject button;
    //[SerializeField] private GameObject[] upgrades;
   // [SerializeField] private Mesh[] upgrades;

   [SerializeField] private Cube[] cubes;
   

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



    public void Upgrade()
    {
        if (stats.PlayerMoney >= upgradeCost && manage.MaxedLevel == false)
        {
            stats.PlayerMoney -= upgradeCost;
            manage.MachineLevel += 1;
            upgradeCost = upgradeCost * 2;

            for (int i = 0; i < 5; i++)
            {
                cubes[i].SellPrice += 1;
            }

            if (manage.MachineLevel >= 5)
            {
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
