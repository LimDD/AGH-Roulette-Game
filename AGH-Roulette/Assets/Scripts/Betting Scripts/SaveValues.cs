using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveValues : MonoBehaviour
{
    public List<int> winNum = new List<int>();
    public string betType;
    public Text bal;
    public Text amount;

    public void SaveInfo(List<int>temp, string type)
    {
        betType = type;

        foreach (int i in temp)
        {
            winNum.Add(i);
        }
    }

    public void WriteToFile()
    {
        string path = "Assets/SavedData/balandamount.txt";
        StreamWriter writer = new StreamWriter(path, true);
        string bet = amount.text;
        string balance = bal.text;

        writer.WriteLine(bet);
        writer.WriteLine(balance);
        writer.Close();
    }
}
