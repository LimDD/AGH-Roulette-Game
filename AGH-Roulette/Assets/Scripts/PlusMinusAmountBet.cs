using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusAmountBet : MonoBehaviour
{
   
    public Text betText;
    public int amountToChange = 10;
    public int maxbet = 300;
    public int minbet = 10;
    
    //Increases the text display
    public void Increment()
    {
        int bettingAmount = TextToInt(betText);

        bettingAmount += amountToChange;

        IntToText(bettingAmount);

    }

    public void Decrement()
    {    
        int bettingAmount = TextToInt(betText);

        bettingAmount -= amountToChange;

        IntToText(bettingAmount);

    }

    private int TextToInt(Text textToConvert)
    {
        int amountBetting = 0;
        amountBetting = int.Parse(textToConvert.text);
        
        return amountBetting;
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
        if(Input.GetButtonDown("Increase Bet Button"))
        {
            Increment();
        }

        if(Input.GetButtonDown("Decrease Bet Button"))
        {
            Decrement();
        }
    }

}
