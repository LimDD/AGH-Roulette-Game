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
    public Button increaseBet;
    public Button decreaseBet;
    

    public void Increment()
    {
        int bettingAmount = ConvertText();

    }

    public void Decrement()
    {    
        int bettingAmount = ConvertText();

    }

    private int ConvertText()
    {
        int amountBetting = 0;
        amountBetting = int.Parse(betText.text);
        
        return amountBetting;
    }

    void Update()
    {
        //on button press: call the increase/decrease functions
    }

}
