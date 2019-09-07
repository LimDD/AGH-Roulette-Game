using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveStatistics : MonoBehaviour
{
    private string path = "/statsFile.txt";
    private List<string> stats = new List<string>();

    public void ReadStats()
    {
        int count = 0;
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        while (!reader.EndOfStream)
        {
            stats.Add(reader.ReadLine());
            count++;
        }
    }

    public void SaveToFile()
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
    }

}
