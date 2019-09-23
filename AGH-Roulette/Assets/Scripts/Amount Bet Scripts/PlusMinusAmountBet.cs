using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;
using TMPro;

public class PlusMinusAmountBet : MonoBehaviour
{
    public TMP_Text betText;
    public TMP_Text playerCoinsText;
    public Button inc;
    public Button dec;
    public Button confirm;
    public int amountToChange = 10;
    public int minBet = 10;
    private string coins;
    private int balance;

    private void Start()
    {
        //If the confirm button isn't interactable then set all buttons back to interactable
        if (!confirm.IsInteractable())
        {
            confirm.interactable = true;
            inc.interactable = true;
            dec.interactable = true;
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

        balance = TextToInt(playerCoinsText);

        //If the balance is less than or equal to 10 then only a bet of 10 can be played
        if (balance <= 10)
        {
            inc.interactable = false;
            dec.interactable = false;
        }

        //THe confirm button cannot be clicked as the player has no money
        if (balance == 0)
        {
            confirm.interactable = false;
            betText.text = "0";
        }
    }

    //Increases the text display
    public void Increment()
    {
        int bettingAmount = 0; 
        int maxBet = 0;

        bettingAmount = TextToInt(betText);
        maxBet = TextToInt(playerCoinsText);

        if (bettingAmount < maxBet)
        {
            bettingAmount += amountToChange;
            IntToText(bettingAmount);
            dec.interactable = true;
        }

        if (bettingAmount == maxBet)
        {
            inc.interactable = false;
        }
    }

    //Decreases the text display
    public void Decrement()
    {
        int bettingAmount = TextToInt(betText);
        
        if(bettingAmount > minBet)
        {
            bettingAmount -= amountToChange;
            IntToText(bettingAmount);
            inc.interactable = true;
        }

        if (bettingAmount == minBet)
        {
            dec.interactable = false;
        }
    }

    private int TextToInt(TMP_Text textToConvert)
    {
        int number = 0;

        string textToString = Regex.Replace(textToConvert.text.ToString(), "[^0-9]", "");

        number = int.Parse(textToString);

        return number;
    }

    private TMP_Text IntToText(int intToConvert)
    {
        TMP_Text convertedInt = betText;

        string text = intToConvert.ToString();
        convertedInt.text = text;
        
        return convertedInt;

    }
}
