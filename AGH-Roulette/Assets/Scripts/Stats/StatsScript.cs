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

    void Start()
    {
        List<string> stats = new List<string>();
        string path = "/statsFile.txt";

        if (!File.Exists(Application.persistentDataPath + path))
        {
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
            writer.Close();
        }

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null && count < 4)
        {
            stats.Add(line);
            count++;
        }

        //If the stats file contains nothing then set all values to 0
        if (stats.Count == 0)
        {
            roundsPlayed.text = "0";
            amountWon.text = "$0";
            amountLost.text = "$0";
            betsMade.text = "0";
            profit.text = "$0";
        }

        else
        {
            calcProfit = int.Parse(stats[3]) - int.Parse(stats[2]);

            roundsPlayed.text = stats[0];
            amountWon.text = "$" + stats[3];
            amountLost.text = "$" + stats[2];
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
}
