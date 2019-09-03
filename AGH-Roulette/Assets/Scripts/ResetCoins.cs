using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    public void ResetFile()
    {
        string path = "Assets/SavedData/balandamount.txt";
        StreamWriter writer = new StreamWriter(path);
        writer.Flush();
        writer.WriteLine("Coins: 500");
        writer.Close();
    }
}
