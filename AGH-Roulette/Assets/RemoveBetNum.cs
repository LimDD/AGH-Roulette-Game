using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RemoveBetNum : MonoBehaviour
{
    public GameObject panel;

    public void CheckPanel()
    {
        if (panel.activeSelf)
        {
            RemoveBet();
        }
    }

    public void RemoveBet()
    {
        string path = "/winningNumbers.txt";

        string line;
        int index = 0;
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        List<string> bets = new List<string>();

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            bets.Add(line);

            if (line.Length > 2)
            {
                index = bets.Count - 1;
            }
        }

        reader.Close();

        while (bets.Count > index)
        {
            bets.RemoveAt(bets.Count - 1);
        }

        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);

        foreach (string s in bets)
        {
            writer.WriteLine(s);
        }

        writer.Close();
    }
}
