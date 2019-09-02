using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningsPayout : MonoBehaviour
{
    public Text bal;
    //In this class I would have an instance of another class storing the balance variable
    public void GetWinnings(string bet)
    {
        int amount = gameObject.GetComponent<DeductCoinsBet>().amountBet;
        int balance = gameObject.GetComponent<DeductCoinsBet>().playerCoins;

        if (bet == "Trio Bet" || bet == "Street Bet")
        {
            balance += amount * 12;
        }

        if (bet == "Odds" || bet == "Evens" || bet == "Reds" || bet == "Blacks")
        {
            balance += amount * 2;
        }

        if (bet == "1st Third" || bet == "2nd Third" || bet == "3rd Third" || bet == "2:1")
        {
            balance += amount * 3;
        }

        if (bet == "Single Bet")
        {
            balance += amount * 36;
        }

        if (bet == "Split Bet")
        {
            balance += amount * 18;
        }

        if (bet == "Corner Bet")
        {
            balance += amount * 9;
        }

        bal.text = "Coins: " + balance.ToString();
    }
}
