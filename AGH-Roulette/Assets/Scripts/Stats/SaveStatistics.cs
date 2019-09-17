using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveStatistics : MonoBehaviour
{
    private string path = "/statsFile.txt";
    private List<int> stats = new List<int>();

    public int ReadStats()
    {
        int temp;
        string line;

        if (!File.Exists(Application.persistentDataPath + path))
        {
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
            writer.Close();
        }

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        while ((line = reader.ReadLine()) != "" && line != null)
        {
            temp = int.Parse(line);
            stats.Add(temp);
        }

        reader.Close();

        return stats.Count;
    }

    public void SaveRounds()
    {
        int count = ReadStats();

        if (count == 0)
        {
            stats.Add(1);
        }

        else
        {
            stats[0]++;
        }

        SaveAmounts(count);
    }

    private void SaveAmounts(int count)
    {
        int amount = 0;
        int bets = 0;
        string line;
        path = "/balandamount.txt";
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        while ((line = reader.ReadLine()) != null)
        {
            if (!(line.Contains("Coins:")))
            {
                amount += int.Parse(line);
                bets++;
            }
        }

        reader.Close();

        if (count == 0)
        {
            stats.Add(bets);
            stats.Add(amount);
            stats.Add(0);
        }

        else
        {
            stats[1] += bets;
            stats[2] += amount;
        }

        path = "/statsFile.txt";
        SaveToFile();
    }

    public void SaveWinnings(int amount, int multi)
    {
        int count = ReadStats();

        stats[2] -= amount;

        stats[3] += amount * (multi - 1);
        SaveToFile();
    }

    private void SaveToFile()
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);

        writer.Flush();
        
        foreach (int i in stats)
        {
            writer.WriteLine(i);
        }

        writer.Close();
    }

}
