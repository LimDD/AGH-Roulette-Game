using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WinningsPayout : MonoBehaviour
{
    public Text bal;
    
    //Finds out the winnings owed due to the bet type and the amount and adds it to the balance
    public int GetWinnings(string bet, int balance, int amount)
    {
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

    //Resets the balandamount text file to only contain the latest balance
    public void ResetFile(int balance)
    {
        bal = GameObject.Find("Balance").GetComponent<Text>();
        string path = "/balandamount.txt";
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.WriteLine("Coins: " + balance.ToString());

        bal.text = "Coins: " + balance.ToString();

        writer.Close();
    }
}
