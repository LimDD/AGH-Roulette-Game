using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DeductCoinsBet : MonoBehaviour
{
    public SoundScript Ss;
    public Text betText;
    public Text playerCoinsText;
    public int amountBet;
    public int playerCoins;

    public void DeductCoins()
    {
        Ss = FindObjectOfType<SoundScript>();
        //Ss.Bet();

        amountBet = 0;
        playerCoins = 0;

        amountBet = TextToInt(betText);
        playerCoins = TextToInt(playerCoinsText);
        
        if (playerCoins >= amountBet)
        {
            playerCoins = playerCoins - amountBet;
        }
        
        IntToTextCoinsText(playerCoins);
    }

    private int TextToInt(Text textToConvert)
    {
        int number = 0;
        //number = int.Parse(textToConvert.text);

        string textToString = Regex.Replace(textToConvert.text.ToString(), "[^0-9]", "");

        number = int.Parse(textToString);

        return number;
    }

    private Text IntToTextCoinsText(int intToConvert)
    {
        Text convertedInt = playerCoinsText;

        string text = intToConvert.ToString();
        convertedInt.text = "Coins: " + text;

        return convertedInt;
    }
}