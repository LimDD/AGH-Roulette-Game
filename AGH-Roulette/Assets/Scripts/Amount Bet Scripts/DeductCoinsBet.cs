using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DeductCoinsBet : MonoBehaviour
{
    public SoundScript Ss;
    public Text betText;
    public Text playerCoinsText;
    //int tempBet = 20; 

    private void Start()
    {
        Ss = FindObjectOfType<SoundScript>();
    }

    public void DeductCoins()
    {
        Ss.Bet();

        int amountBet = 0;
        int playerCoins = 0;

        //amountBet = TextToInt(betText);
        amountBet = TextToInt(betText);
        playerCoins = TextToInt(playerCoinsText);
        
        if (playerCoins >= amountBet)
        {
            playerCoins = playerCoins - amountBet;
        }
        
        IntToTextCoinsText(playerCoins);
        int resetBet = 10;
        IntToText(resetBet);
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

    private Text IntToText(int intToConvert)
    {
        Text convertedInt = betText;

        string text = intToConvert.ToString();
        convertedInt.text = text;

        return convertedInt;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetButtonDown("Confirm Bet Button"))
        {
            DeductCoins();
        }
        */
    }
}
