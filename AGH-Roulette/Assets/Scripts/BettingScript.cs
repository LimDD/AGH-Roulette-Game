using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//In this scenario, the player is losing 1 coin per bet
public class BettingScript : MonoBehaviour
{
    public Button button;
    public Text bal;
    public Text noBal;
    public int coins;
    public AudioScript aS;

    void Start()
    {
        aS = FindObjectOfType<AudioScript>();

        coins = 5;
        bal = GameObject.Find("Canvas/BalText").GetComponent<Text>();
        bal.text = "Balance = "+ coins.ToString();

        noBal = GameObject.Find("Canvas/noCoinsText").GetComponent<Text>();
        noBal.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        noBal.gameObject.SetActive(false);

        if (coins > 0)
        {
            aS.Bet();
            coins--;
            //Check if player is now out of coins
            if (coins == 0)
            {
                //This seems to override the button click sound when the player is out of coins
                aS.NoCoins();
                noBal.gameObject.SetActive(true);
                button.GetComponent<Image>().color = Color.red;
            }

            bal.text = "Balance = " + coins.ToString();
        }

        else
        {
            aS.ErrSound();
        }

    }
}

