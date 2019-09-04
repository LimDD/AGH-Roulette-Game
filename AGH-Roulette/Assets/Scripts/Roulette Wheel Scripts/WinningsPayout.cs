using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WinningsPayout : MonoBehaviour
{
    public Text bal;
    //In this class I would have an instance of another class storing the balance variable
    public int GetWinnings(string bet, int index, int balance)
    {
        List<string> betInfo = new List<string>();
        string line;
        string path = "Assets/SavedData/balandamount.txt";
        StreamReader reader = new StreamReader(path);

        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            betInfo.Add(line);
            count++;
        }

        reader.Close();

        Int32.TryParse(betInfo[index + 2], out int amount);

        if (bet == "Trio Bet" || bet == "Street Bet")
        {
            balance += amount * 12;
        }

        if (bet == "Odds" || bet == "Evens" || bet == "Red" || bet == "Black" || bet == "1 To 18" || bet == "19 to 36")
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


        return balance;
    }

    public void ResetFile(int balance, string path)
    {
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine("Coins: " + balance.ToString());
        writer.Close();
    }
}
