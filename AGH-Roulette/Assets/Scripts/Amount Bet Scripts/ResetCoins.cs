using System.IO;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    public void ResetFile()
    {
        string path = "/balandamount.txt";

        if (!File.Exists(Application.persistentDataPath + path))
        {
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
            writer.WriteLine("Coins: 500");
            writer.Close();
        }
    }
}
