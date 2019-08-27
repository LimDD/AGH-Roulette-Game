using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlusMinusAmountBet : MonoBehaviour
{
    public SoundScript Ss;
    public Text betText;
    public Text playerCoinsText;
    public int amountToChange = 10;
    public int minBet = 10;

    private void Start()
    {
        Ss = FindObjectOfType<SoundScript>();
    }

    //Increases the text display
    public void Increment()
    {
        Ss.Bet();
        int bettingAmount = 0; 
        int maxBet = 0;

        bettingAmount = TextToInt(betText);
        maxBet = TextToInt(playerCoinsText);

        if (bettingAmount <= maxBet)
        {
            bettingAmount += amountToChange;
            IntToText(bettingAmount);
        }
        

    }

    public void Decrement()
    {
        Ss.Bet();
        int bettingAmount = TextToInt(betText);
        
        if(bettingAmount > minBet)
        {
            bettingAmount -= amountToChange;
            IntToText(bettingAmount);
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
    void Update()
    {
        //on button press: call the increase/decrease functions
       /* if(Input.GetButtonDown("Increase Bet Button"))
        {
            Increment();
        }

        if(Input.GetButtonDown("Decrease Bet Button"))
        {
            Decrement();
        }
        */
    }

}
