using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalCheck : MonoBehaviour
{
    public Button confirm;
    public TMP_Text playerCoinsText;
    public TMP_Text betText;

    string coins;
    int balance;

    public void CheckBal()
    {
        //If the confirm button isn't interactable then set all buttons back to interactable
        if (!confirm.IsInteractable())
        {
            confirm.interactable = true;
        }

        string path = "/balandamount.txt";
        string temp;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        //Gets the latest coin value to be shown to the player
        while (!reader.EndOfStream)
        {
            temp = reader.ReadLine();
            if (temp.Contains("Coins"))
            {
                coins = temp;
            }
        }

        reader.Close();

        playerCoinsText.text = coins;

        temp = Regex.Replace(playerCoinsText.text, "[^0-9]", "");

        balance = int.Parse(temp);

        int amount = int.Parse(betText.text);

        if (amount > balance)
        {
            amount = balance;
            betText.text = amount.ToString();
        }

        //THe confirm button cannot be clicked as the player has no money
        if (balance == 0)
        {
            confirm.interactable = false;
            betText.text = "0";
        }
    }
}

