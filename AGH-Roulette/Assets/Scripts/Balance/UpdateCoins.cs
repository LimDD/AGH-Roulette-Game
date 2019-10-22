using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class UpdateCoins : MonoBehaviour
{
    public TMP_Text playerCoins;
    NumberReaderScript nRS;
    string coins;

    // Start is called before the first frame update
    void Start()
    {
        string path = "/balandamount.txt";
        string temp;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        //Gets the latest coin value to be shown to the player
        while (!reader.EndOfStream)
        {
            temp = reader.ReadLine();
            if (temp.Contains("Coins:"))
            {
                coins = temp;
            }
        }

        reader.Close();

        playerCoins.text = coins;
    }

    public void ReadBalance()
    {
        nRS = FindObjectOfType<NumberReaderScript>();
        string temp = playerCoins.text;

        temp = Regex.Replace(temp, "Coins: ", "");

        int i = int.Parse(temp);

        nRS.SetNumber(i);

        nRS.ReadNumber();
    }
}
