using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script would collect the information from other scripts containing player statistics to be displayed.
public class StatsScript : MonoBehaviour
{
    public FakeScores fS;
    public Text roundsPlayed;
    public Text amountWon;
    public Text amountLost;
    public Text betsMade;
    public Text profit;
    public Text checkWinnings;
    public int calcProfit;

    // Start is called before the first frame update
    void Start()
    {
        //Give access to another script, in the real game all relevant scripts will need to be added.
        fS = FindObjectOfType<FakeScores>();

        roundsPlayed = GameObject.Find("RP").GetComponent<Text>();
        amountWon = GameObject.Find("AW").GetComponent<Text>();
        amountLost = GameObject.Find("AL").GetComponent<Text>();
        betsMade = GameObject.Find("BM").GetComponent<Text>();
        profit = GameObject.Find("Pt").GetComponent<Text>();
        checkWinnings = GameObject.Find("Profit").GetComponent<Text>();


        calcProfit = fS.aWon - fS.aLost;

        roundsPlayed.text = fS.rounds.ToString();
        amountWon.text = "$"+ fS.aWon.ToString();
        amountLost.text = "$"+ fS.aLost.ToString();
        betsMade.text = fS.betNum.ToString();

        //Checks if the profit is negative, so the - can go infront of the $.
        if (calcProfit < 0)
        {
            checkWinnings.text = "Total Losses:";
            calcProfit *= -1;
            profit.text = "-$" + calcProfit.ToString();
        }

        else
        {
            profit.text = "$" + calcProfit.ToString();
        }
    }
}
