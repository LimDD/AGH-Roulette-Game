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
        string bet = amount.text;
        string balance = bal.text;

        writer.WriteLine(balance);
        writer.WriteLine(bet);
        writer.Close();
    }
}
