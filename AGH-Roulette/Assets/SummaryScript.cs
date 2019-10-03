using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SummaryScript : MonoBehaviour
{
    public Text betsMade;
    public Text amountWon;
    public Text amountLost;
    public Text winnings;
    public Text profit;

    // Start is called before the first frame update
    void Start()
    {
        List<string> summary = new List<string>();
        string path = "/statsFile.txt";

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null && count > 3)
        {
            summary.Add(line);
            count++;
        }

        reader.Close();

        int calcProfit = int.Parse(summary[2]) - int.Parse(summary[1]);

        betsMade.text = summary[0];
        amountWon.text = "$" + summary[2];
        amountLost.text = "$" + summary[1];

        //Checks if the profit is negative, so the - can go infront of the $.
        if (calcProfit < 0)
        {
            profit.text = "Total Losses:";
            calcProfit *= -1;
            winnings.text = "-$" + calcProfit.ToString();
        }

        else
        {
            winnings.text = "$" + calcProfit.ToString();
        }

    }
}
