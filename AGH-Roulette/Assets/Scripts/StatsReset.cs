using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StatsReset : MonoBehaviour
{
    private List<string> stats;

    public void ClearSummary()
    {
        stats = new List<string>();

        string path = "/statsFile.txt";

        if (File.Exists(Application.persistentDataPath + path))
        {

            StreamReader reader = new StreamReader(Application.persistentDataPath + path);

            string line;
            int count = 0;

            while ((line = reader.ReadLine()) != null && count < 4)
            {
                stats.Add(line);
                count++;
            }

            reader.Close();

            StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);

            writer.Flush();

            foreach (string s in stats)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }
    }
}
