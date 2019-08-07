using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//In this scenario, the player is losing 1 coin per bet
public class BettingScript : MonoBehaviour
{
    public Button button;
    public Text bal;
    public int coins;
    public AudioScript aS;

    void Start()
    {
        coins = 5;
        bal = GameObject.Find("Canvas/Text").GetComponent<Text>();
        bal.text = "Balance = "+ coins.ToString();
        aS = FindObjectOfType<AudioScript>();
    }

    public void OnClick()
    {
        if (coins > 0)
        {
            aS.Bet();
            coins--;
            //Check if player is now out of coins
            if (coins == 0)
            {
                //This seems to override the button click sound when the player is out of coins
                aS.NoCoins();
            }

            bal.text = "Balance = " + coins.ToString();
        }

        else
        {
            aS.ErrSound();
        }

    }

}

