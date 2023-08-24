using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BettingSlider : MonoBehaviour
{
    public Slider slider;
    public PlayerStats player;
    public int BetAmount;
    public TMP_Text BetText;


    void Start()
    {
        //slider.maxValue = player.PlayerMoney; // TEST
        //slider.value = 0;
        //BetText.text = "Bet Amount: $" + BetAmount.ToString();
    }


    void Update()
    {
        //slider.maxValue = player.PlayerMoney;
    }

    public void RefreshBet()
    {
        slider.value = 1;
    }


    public void PlaceBet()
    {
        if (player.PlayerMoney > 0) //&& player.PlayerMoney >= BetAmount)
        {
            slider.maxValue = player.PlayerMoney; // TEST
            BetAmount = Mathf.RoundToInt(slider.value);
            BetText.text = "Bet Amount: $" + BetAmount.ToString();
            //Debug.Log("Placing Bet");
        }
        else
        {
            return;
        }
    }

    public void ConfirmBet()
    {
        if (player.PlayerMoney >= BetAmount)
        player.PlayerMoney -= BetAmount;
        Debug.Log("Bet Confirmed: + $" + BetAmount.ToString());
    }

}
