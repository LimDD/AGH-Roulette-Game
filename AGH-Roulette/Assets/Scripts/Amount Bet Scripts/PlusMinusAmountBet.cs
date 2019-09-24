using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
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
