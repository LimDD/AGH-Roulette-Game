using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusAmountBet : MonoBehaviour
{
    /*
    public Text betText;
    public int amountToBet = 20;
    public int increaseBet = 10;
    public int decreaseBet = 10;
          
    void Update()
    {
        betText.text = "" + amountToBet + "";

    }

    public void ClickToIncrease()
    {
        amountToBet += increaseBet;
    }

    public void ClickToDecrease()
    {
        amountToBet -= decreaseBet;
    }
    */


    public Text betText;
    public int amountToBet = 10;
    public int maxbet = 300;

    public void TextToString(Text betText)
    {
        //betText.GetComponent<UnityEngine.UI.Text>().text
    }

    public void Increment()
    {
        if(amountToBet < maxbet)
        {
            amountToBet += 10;
            UpdateText(amountToBet);
        }

    }

    public void Decrement()
    {
        if (amountToBet > 1)
        {
            amountToBet -= 10;
            UpdateText(amountToBet);
        }
        
    }

    public void UpdateText(int bettingAmount)
    {
        betText.text = bettingAmount.ToString();
    }

}
