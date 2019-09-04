using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveValues : MonoBehaviour
{
    public Text bal;
    public Text amount;

    public void WriteToFile()
    {
        string path = "Assets/SavedData/balandamount.txt";
        StreamWriter writer = new StreamWriter(path, true);
        string balance = bal.text;
        string bet = amount.text;

        writer.WriteLine(balance);
        writer.WriteLine(bet);
        writer.Close();
    }
}
