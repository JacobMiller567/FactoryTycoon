using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int PlayerMoney;
    [SerializeField] TextMeshProUGUI moneyText;
    // Player Health


    void Update()
    {
        moneyText.text = "$" + PlayerMoney.ToString(); 
    }


}
