using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeductCoinsBet : MonoBehaviour
{

    public Text betText;
    public Text playerCoinsText;
    

    public void DeductCoins()
    {
        int amountBet = 0;
        int playerCoins = 0;

        amountBet = TextToInt(betText);
        playerCoins = TextToInt(playerCoinsText);

        playerCoins = playerCoins - amountBet;

        IntToText(playerCoins);
        ResetAmountToBet();
    }

    private int TextToInt(Text textToConvert)
    {
        int number = 0;
        number = int.Parse(textToConvert.text);

        return number;
    }

    private Text IntToText(int intToConvert)
    {
        Text convertedInt = playerCoinsText;

        string text = intToConvert.ToString();
        convertedInt.text = "Coins: " + text;

        return convertedInt;
    }

    private int ResetAmountToBet()
    {
        int setMinBet = 10;

        return setMinBet;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Confirm Bet Button"))
        {
            DeductCoins();
        }
    }
}
