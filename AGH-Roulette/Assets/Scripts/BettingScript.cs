using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//In this scenario, the player is losing 1 coin per bet
//There is no way to add more coins
public class BettingScript : MonoBehaviour
{
    public Button button;
    public Text bal;
    public Text noBal;
    public Text hi;
    public int coins;
    public AudioScript aS;

    void Start()
    {
        aS = FindObjectOfType<AudioScript>();

        coins = 5;
        bal = GameObject.Find("BalText").GetComponent<Text>();
        bal.text = "Balance = "+ coins.ToString();

        noBal = GameObject.Find("NoCoinsText").GetComponent<Text>();
        noBal.GetComponent<Text>().enabled = false;
    }

    public void OnClick()
    {
        if (coins > 0)
        {
            aS.Bet();
            coins--;
            //Check if player is now out of coins.
            if (coins == 0)
            {
                aS.NoCoins();
                //Shows on screen text saying the user is out of coins.
                noBal.GetComponent<Text>().enabled = true;
                Destroy(noBal, 2);
                //Button cannot be clicked now.
                button.GetComponent<Button>().interactable = false;
            }
            //Shows Player balance
            bal.text = "Balance = " + coins.ToString();
        }

        //In case you want button to be clickable, a sound will play when the user has no coins
        //And tries to bet.
        else
        {
            aS.ErrSound();
        }

    }
}

