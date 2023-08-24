using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckWin : MonoBehaviour
{
    //public Slots[] slotNumbers;
    public BettingSlider bet;
    public PlayerStats player;
    public bool win = false;
    public TMP_Text WinText;
    public GameObject WinHold;

    // 1x win if 2 in a row?
    // 2x win if double 2 in a row?
    // 3x win if 3 in a row
    // 5x win if 4 in a row 
    public void CheckForWin() // Check for 4 in a row 
    {
     
        bool isSame = true;
        //bool three = true;
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                isSame = transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(i + 1).GetComponent<UnityEngine.UI.Image>().sprite;
            }
            else
            {
                isSame = isSame && transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(i + 1).GetComponent<UnityEngine.UI.Image>().sprite;
            }

            
        }

        if (isSame)
        {
            Debug.Log("FOUR IN A ROW!");
            player.PlayerMoney += (5 * bet.BetAmount); // 5x wins
            win = true;
            WinHold.SetActive(true);
            WinText.text = "Winnings: $" + (5 * bet.BetAmount); 

        }
        else
        {
          Debug.Log("Not four in a row!");
        }
    }

    public void ThreeInARow() // Check for 3 in a row out of 4 given slots
    {

        // If not already 4 in a row...
        if (win != true)
        {

            // Check if images: 0, 1, 2 are the same
            bool frontSame = true;
            bool backSame = true;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    frontSame = transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(i + 1).GetComponent<UnityEngine.UI.Image>().sprite;
                }
                else
                {
                    frontSame = frontSame && transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(i + 1).GetComponent<UnityEngine.UI.Image>().sprite;
                }
            }
            if (frontSame)
            {
                Debug.Log("Three in a row!");
                player.PlayerMoney += (3 * bet.BetAmount); // 3x wins
                WinHold.SetActive(true);
                WinText.text = "Winnings: $" + (3 * bet.BetAmount);
                return;
            }


            if (!frontSame) // TEST! See if this fixes problem
            {
                // Check if images: 1, 2, 3 are the same
                for (int j = 3; j > 0; j--)
                {
                    if (j == 3)
                    {
                        backSame = transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(j - 1).GetComponent<UnityEngine.UI.Image>().sprite;
                    }
                    else
                    {
                        backSame = backSame && transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(j - 1).GetComponent<UnityEngine.UI.Image>().sprite;
                    }
                }
                if (backSame)
                {
                    Debug.Log("Three in a row!");
                    player.PlayerMoney += (3 * bet.BetAmount); // 3x wins
                    WinHold.SetActive(true);
                    WinText.text = "Winnings: $" + (3 * bet.BetAmount);
                    return;
                }
            }

            // Else: Not 3 in a row
            else
            {
                Debug.Log("Not three in a row!");
            }

        }

        // Else: Already 4 in a row
        else
        {
            Debug.Log("Already four in a row!");
        }
    }

/*
    public void CheckBackThree() // Check for 3 in a row out of 4 given slots
    {
        for (int j = 3; j > 0; j--)
        {
            if (j == 3)
            {
                backSame = transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(j - 1).GetComponent<UnityEngine.UI.Image>().sprite;
            }
            else
            {
                backSame = backSame && transform.GetChild(j).GetComponent<UnityEngine.UI.Image>().sprite == transform.GetChild(j - 1).GetComponent<UnityEngine.UI.Image>().sprite;
            }
        }
        if (backSame)
        {
            Debug.Log("Three in a row!");
            player.PlayerMoney += (3 * bet.BetAmount); // 3x wins
            WinHold.SetActive(true);
            WinText.text = "Winnings: $" + (3 * bet.BetAmount);
            return;
        }

    }
*/


}
