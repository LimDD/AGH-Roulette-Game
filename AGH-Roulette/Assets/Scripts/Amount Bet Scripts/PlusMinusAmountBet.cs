using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;

public class PlusMinusAmountBet : MonoBehaviour
{
    public SoundScript Ss;
    public Text betText;
    public Text playerCoinsText;
    public Button inc;
    public Button dec;
    public Button confirm;
    public int amountToChange = 10;
    public int minBet = 10;
    private string coins;
    private int balance;

    private void Start()
    {
        if (!confirm.IsInteractable())
        {
            confirm.interactable = true;
            inc.interactable = true;
            dec.interactable = true;
        }

        Ss = FindObjectOfType<SoundScript>();
        string path = "/balandamount.txt";
        string temp;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

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

        if (balance <= 10)
        {
            inc.interactable = false;
            dec.interactable = false;
        }

        if (balance == 0)
        {
            confirm.interactable = false;
            betText.text = "0";
        }
    }

    //Increases the text display
    public void Increment()
    {
        Ss.Bet();
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
        Ss.Bet();
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

    private int TextToInt(Text textToConvert)
    {
        int number = 0;

        string textToString = Regex.Replace(textToConvert.text.ToString(), "[^0-9]", "");

        number = int.Parse(textToString);

        return number;
    }

    private Text IntToText(int intToConvert)
    {
        Text convertedInt = betText;

        string text = intToConvert.ToString();
        convertedInt.text = text;
        
        return convertedInt;

    }
}
