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
    public void GetWinnings(string bet, int index)
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

        string temp = betInfo[count - 1];

        temp = Regex.Replace(temp, "[^0-9.]", "");

        int balance = Int32.Parse(temp);

        Int32.TryParse(betInfo[index], out int amount);

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

        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(balance.ToString());
        writer.Close();
    }
}
