using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockNewRoom : MonoBehaviour
{
    //public BuildMenu build;
    public PlayerStats stats;
    public int expansionCost;
    public GameObject button;
    public GameObject room;
    public TMP_Text landCostText;
    private bool onPlate = false;
    public bool firstExpansion;
    public bool secondExpansion;



    public void Update()
    {
        if (onPlate)
        {
            landCostText.text = "Expansion: $" + expansionCost.ToString();
        }
    }



    void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            onPlate = true;
            button.SetActive(true);
        }
    }
    void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.tag == "Player")
        {
            onPlate = false;
            button.SetActive(false);
        }
    }

    public void ExpansionOne()
    {
        if (stats.PlayerMoney >= expansionCost)
        {
            stats.PlayerMoney -= expansionCost;
            room.SetActive(false);
            firstExpansion = true;
            //expansionCost = expansionCost * 8;
            //land.transform.localScale += new Vector3(1f, 1f, 1f);
            landCostText.text = "Expansion: $" + expansionCost.ToString();

            gameObject.SetActive(false); // Hide pressure plate
        }
    }

    public void ExpansionTwo()
    {
        if (stats.PlayerMoney >= expansionCost)
        {
            stats.PlayerMoney -= expansionCost;
            room.SetActive(true);
            secondExpansion = true;
            //expansionCost = expansionCost * 8;
            //land.transform.localScale += new Vector3(1f, 1f, 1f);
            landCostText.text = "Expansion: $" + expansionCost.ToString();

            gameObject.SetActive(false); // Hide pressure plate
        }
    }



}
