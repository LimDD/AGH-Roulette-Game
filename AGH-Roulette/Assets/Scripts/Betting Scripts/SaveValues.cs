using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveValues : MonoBehaviour
{
    public List<int> winNum = new List<int>();
    public string betType;

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
        string path = "Assets/SavedData/winningNumbers.txt";

        //Write some text to the winningNumbers.txt file
        StreamWriter writer = new StreamWriter(path, true);

        Debug.Log("wtf: " + betType);
        writer.WriteLine(betType);
        foreach (int i in winNum)
        {
            Debug.Log("wtf: "+i);
            writer.WriteLine(i);
        }

        writer.Close();
        winNum.Clear();

        ReadString();
    }

    private void ReadString()
    {
        string path = "Assets/SavedData/winningNumbers.txt";

        //Display the file text in the Debug.Log
        StreamReader reader = new StreamReader(path);
        Debug.Log("Reader: " + reader.ReadToEnd());
        reader.Close();
    }

}
