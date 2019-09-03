using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.IO;

public class DeductCoinsBet : MonoBehaviour
{
    public SoundScript Ss;
    public Text betText;
    public Text playerCoinsText;
    public int amountBet;
    public int playerCoins;
    //int tempBet = 20; 
    public bool firstRun = false;

    private void Start()
    {
        string path = "Assets/SavedData/balandamount.txt";
        string line;
        Ss = FindObjectOfType<SoundScript>();

        if (firstRun)
        {
            StreamReader reader = new StreamReader(path);

            if ((line = reader.ReadLine()) != null)
            {
                playerCoinsText.text = line;
            }

            reader.Close();
        }

        else
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Flush();
            writer.Close();

            playerCoinsText.text = "Coins: 500";
            firstRun = true;
        }
    }

    public void DeductCoins()
    {
        Ss.Bet();

        amountBet = 0;
        playerCoins = 0;

        //amountBet = TextToInt(betText);
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
