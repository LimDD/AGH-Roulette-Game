using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveValues : MonoBehaviour
{
    public TMP_Text bal;
    public TMP_Text amount;

    //Saves the balance and the bet amounts into a text file
    public void WriteToFile()
    {
        string path = "/balandamount.txt";
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path, true);
        string balance = bal.text;
        string bet = amount.text;

        balance = Regex.Replace(balance, "Coins: ", "");

        int balNum = int.Parse(balance) - int.Parse(bet);

        balance = "Coins: " + balNum.ToString();

        bal.text = balance;

        writer.WriteLine(balance);
        writer.WriteLine(bet);
        writer.Close();
    }
}
