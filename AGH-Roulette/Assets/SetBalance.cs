using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetBalance : MonoBehaviour
{
    private string path;

    //Gets the first balance in the text file, meaning if the user goes back to the menu without playing their bets
    //They will keep their coins
    public void GetLastCoins()
    {
        path = "/balandamount.txt";
        string lastCoins;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        lastCoins = reader.ReadLine();

        reader.Close();

        SetLastCoins(lastCoins);
        
    }

    //Saves the last coins as the only item in the text file
    private void SetLastCoins(string coins)
    {
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);

        writer.WriteLine(coins);

        writer.Close();
    }
}
