using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingScript : MonoBehaviour
{
    public Button button;
    public Text bal;
    public int coins;

    void Start()
    {
        coins = 5;
        //Not sure how to fix the error that appears.
        bal = GameObject.Find("Canvas/Text").GetComponent<Text>();
        bal.text = "Balance = "+ coins.ToString();
    }

    public void OnClick()
    {
        Debug.Log("You have clicked the button!");

        if (coins > 0)
        {
            coins--;
            Debug.Log("You have "+coins+" coins left.");

            bal.text = "Balance = " + coins.ToString();
        }

        else
        {
            Debug.Log("Error, You are out of coins");
        }
    }
}

