using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeDropper : MonoBehaviour
{
    private int clickRange = 2;
    public int upgradeCost;
    public bool onPlate = false;
    public Transform player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject[] droppers;
    private int count = 1;

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


    public void AddDropper()
    {
        if (stats.PlayerMoney >= upgradeCost && manage.MaxedLevel == false)
        {
            stats.PlayerMoney -= upgradeCost;
            manage.MachineLevel += 1;
            upgradeCost = upgradeCost * 2;
            droppers[count].SetActive(true);
            count += 1;
            Debug.Log(count);

            if (count >= 4)
            {
                manage.MaxedLevel = true;
            }

            /*
            for (int i = count; i < count + 1; i ++)
            {
                droppers[i].SetActive(true);
            }
            */
            //droppers[count].SetActive(true);
            //count += 1;
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
