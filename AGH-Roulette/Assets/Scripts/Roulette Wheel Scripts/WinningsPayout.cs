using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class WinningsPayout : MonoBehaviour
{
    public TMP_Text bal;
    
    //Finds out the winnings owed due to the bet type and the amount and adds it to the balance
    public int GetWinnings(string bet, int balance, int amount)
    {
        Debug.Log("Amount: " + amount);

        int multi = 0;

        if (bet == "Trio Bet" || bet == "Street Bet")
        {
            multi = 12;
        }

        else if (bet == "Odds" || bet == "Evens" || bet == "Red" || bet == "Black" || bet == "1 To 18" || bet == "19 To 36")
        {
            multi = 2;
        }

        else if (bet == "1st Third" || bet == "2nd Third" || bet == "3rd Third" || bet == "2:1")
        {
            multi = 3;
        }

        else if (bet == "Six Line Bet")
        {
            multi = 6;
        }

        else if (bet == "Basket Bet")
        {
            multi = 7;
        }

        else if(bet == "Single Bet")
        {
            multi = 36;
        }

        else if(bet == "Split Bet")
        {
            multi = 18;
        }

        else if(bet == "Corner Bet")
        {
            multi = 9;
        }

        balance += amount * multi;

        SaveStatistics stats = FindObjectOfType<SaveStatistics>();

        stats.SaveWinnings(amount, multi);

        return balance;
    }

    //Resets coins back to original balance for main game
    public void SetBal(int balance)
    {
        bal.text = "Coins: " + balance.ToString();

        string path = "/balandamount.txt";
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        List<string> balData = new List<string>(); 

        while (!reader.EndOfStream)
        {
            balData.Add(reader.ReadLine());
        }

        reader.Close();

        balData.RemoveAt(balData.Count - 1);
        balData.RemoveAt(balData.Count - 1);



        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.WriteLine(balData[balData.Count - 1]);

        writer.Close();
    }

    //Resets the balandamount text file to only contain the latest balance
    public void ResetFile(int balance)
    {
        string path = "/balandamount.txt";
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.WriteLine("Coins: " + balance.ToString());

        bal.text = "Coins: " + balance.ToString();

        writer.Close();
    }
}
