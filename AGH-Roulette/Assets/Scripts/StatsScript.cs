using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//This script collects the information from the statsFile text file containing player statistics so it can be displayed.
public class StatsScript : MonoBehaviour
{
    public Text roundsPlayed;
    public Text amountWon;
    public Text amountLost;
    public Text betsMade;
    public Text profit;
    public Text checkWinnings;
    public int calcProfit;

    public void ShowStats()
    {
        roundsPlayed = GameObject.Find("RP").GetComponent<Text>();
        amountWon = GameObject.Find("AW").GetComponent<Text>();
        amountLost = GameObject.Find("AL").GetComponent<Text>();
        betsMade = GameObject.Find("BM").GetComponent<Text>();
        profit = GameObject.Find("Pt").GetComponent<Text>();
        checkWinnings = GameObject.Find("Profit").GetComponent<Text>();

        string path = "/statsFile.txt";
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        List<string> stats = new List<string>();

        while (!reader.EndOfStream)
        {
            stats.Add(reader.ReadLine());
        }


        calcProfit = int.Parse(stats[3]) - int.Parse(stats[2]);

        roundsPlayed.text = stats[0];
        amountWon.text = "$"+ stats[3];
        amountLost.text = "$"+ stats[2];
        betsMade.text = stats[1];

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
