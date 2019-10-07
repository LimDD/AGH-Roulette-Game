using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SetBalance : MonoBehaviour
{
    public TMP_Text coins;
    private string path;
    private List<string> saveData;

    //Gets the first balance in the text file, meaning if the user goes back to the menu without playing their bets
    //They will keep their coins
    public void GetLastCoins()
    {
        saveData = new List<string>();
        path = "/balandamount.txt";
        string line;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();

            saveData.Add(line);
        }

        reader.Close();

        saveData.RemoveAt(saveData.Count - 1);
        saveData.RemoveAt(saveData.Count - 1);

        if (saveData.Count == 1)
        {
            coins.text = saveData[0];
        }

        else
        {
            coins.text = saveData[saveData.Count - 2];
        }

        SetLastCoins();
    }

    public void FirstCoins()
    {
        saveData = new List<string>();
        path = "/balandamount.txt";
        string line;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        line = reader.ReadLine();
        saveData.Add(line);
        reader.Close();

        if (coins != null)
        {
            coins.text = saveData[0];
        }
        SetLastCoins();
    }

    //Rewrites the text file to remove the removed bet and balance
    private void SetLastCoins()
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.Flush();

        foreach (string s in saveData)
        {
            writer.WriteLine(s);
        }

        writer.Close();
    }
}
