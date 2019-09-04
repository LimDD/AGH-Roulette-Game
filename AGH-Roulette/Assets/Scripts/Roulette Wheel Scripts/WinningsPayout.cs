using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WinningsPayout : MonoBehaviour
{
    //In this class I would have an instance of another class storing the balance variable
    public int GetWinnings(string bet, int balance, int amount)
    {
        if (bet == "Trio Bet" || bet == "Street Bet")
        {
            balance += amount * 12;
        }

        else if (bet == "Odds" || bet == "Evens" || bet == "Red" || bet == "Black" || bet == "1 To 18" || bet == "19 To 36")
        {
            balance += amount * 2;
        }

        else if(bet == "1st Third" || bet == "2nd Third" || bet == "3rd Third" || bet == "2:1")
        {
            balance += amount * 3;
        }

        else if(bet == "Single Bet")
        {
            balance += amount * 36;
        }

        else if(bet == "Split Bet")
        {
            balance += amount * 18;
        }

        else if(bet == "Corner Bet")
        {
            balance += amount * 9;
        }

        return balance;
    }

    public void ResetFile(int balance)
    {
        string path = "/balandamount.txt";
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.WriteLine("Coins: " + balance.ToString());
        writer.Close();
    }
}
