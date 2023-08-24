using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
   public Sprite[] sprites;
   //public PlayerStats player;
   public float time;
   public bool play = false;
   public CheckWin check;
   public SlotManager manage;

   void Update()
   {  
      RandomImage();
      //CheckImages();
   }

   public void RandomImage()
   {
      gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprites[Random.Range(0, sprites.Length)];
   }

   public void EnableOff()
   {
      Invoke("DelayNum", time);
      StartCoroutine(CheckSprite());
   }

    public void EnableOn()
    {
      enabled = true;
    }

   void DelayNum()
   {
      enabled = false;
   }

   IEnumerator CheckSprite()
   {
      yield return new WaitForSeconds(time);
      {
         manage.spriteCheck.Add(gameObject.GetComponent<UnityEngine.UI.Image>().sprite); 
         manage.Count += 1;

         if (manage.Count >= 4) // 0.08% chance of 4 in a row!
         {
            check.CheckForWin();

            manage.Restart(); // Displays replay and quit buttons!

            if (check.win != true)
            {
               check.ThreeInARow();
               //check.CheckBackThree(); // potential fix?

            }
         }
      }
   }


}
