using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinusAmountBet : MonoBehaviour
{
    /*
    public UnityEngine.UI.Text betText;
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

    public UnityEngine.UI.Text betText;
    public int amountToBet = 0;

    public void TextToString(UnityEngine.UI.Text betText)
    {
        //betText.GetComponent<UnityEngine.UI.Text>().text
    }

    public void Increment()
    {
        amountToBet += 10;
        UpdateText(amountToBet);
    }

    public void Decrement()
    {
        amountToBet -= 10;
        UpdateText(amountToBet);
    }

    public void UpdateText(int bettingAmount)
    {
        betText.text = bettingAmount.ToString();
    }

}
