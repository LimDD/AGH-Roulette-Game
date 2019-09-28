using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class SaveValues : MonoBehaviour
{
    public TMP_Text bal;
    public TMP_Text amount;
    SceneSwitcher sS;
    public GameObject panel;
    public GameObject table;

    //Saves the balance and the bet amounts into a text file
    public void WriteToFile()
    {
        sS = gameObject.GetComponent<SceneSwitcher>();
        string balance = bal.text;
        string bet = amount.text;

        balance = Regex.Replace(balance, "Coins: ", "");

        int balNum = int.Parse(balance) - int.Parse(bet);

        balance = "Coins: " + balNum.ToString();

        bal.text = balance;

        string path = "/balandamount.txt";
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path, true);

        writer.WriteLine(balance);
        writer.WriteLine(bet);
        writer.Close();

        CheckBal(balNum);
    }

    private void CheckBal(int balNum)
    {
        if (balNum == 0)
        {
            table.SetActive(false);
            sS.WheelScene();
        }

        else
        {
            panel.SetActive(true);
        }
    }
}
