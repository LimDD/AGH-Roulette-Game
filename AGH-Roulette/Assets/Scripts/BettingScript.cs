using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingScript : MonoBehaviour
{
    public Button button;
    public Text bal;
    public int coins;
    public AudioScript aS;

    void Start()
    {
        coins = 5;
        bal = GameObject.Find("Canvas/Text").GetComponent<Text>();
        bal.text = "Balance = "+ coins.ToString();
        aS = FindObjectOfType<AudioScript>();
    }

    public void OnClick()
    {
        if (coins > 0)
        {
            coins--;
            Debug.Log("You have "+coins+" coins left.");

            bal.text = "Balance = " + coins.ToString();
        }

        else
        {
            Debug.Log("Error, You are out of coins");
            aS.NoCoins();
        }
    }
}

