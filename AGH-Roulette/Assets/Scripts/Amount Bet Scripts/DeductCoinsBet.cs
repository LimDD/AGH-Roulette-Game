using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class DeductCoinsBet : MonoBehaviour
{
    public TMP_Text betText;
    public TMP_Text playerCoinsText;
    public int amountBet;
    public int playerCoins;

    public void DeductCoins()
    {
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

    private int TextToInt(TMP_Text textToConvert)
    {
        int number = 0;

        string textToString = Regex.Replace(textToConvert.text.ToString(), "[^0-9]", "");

        number = int.Parse(textToString);

        return number;
    }

    private TMP_Text IntToTextCoinsText(int intToConvert)
    {
        TMP_Text convertedInt = playerCoinsText;

        string text = intToConvert.ToString();
        convertedInt.text = "Coins: " + text;

        return convertedInt;
    }
}