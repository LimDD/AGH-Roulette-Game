using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteInfotoFile : MonoBehaviour
{
    SaveBetInfo sBI;

    private void Awake()
    {
        string path = "Assets/SavedData/winningNumbers.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);

        writer.Flush();
        writer.Close();
    }

    public void WriteToFile()
    {
        sBI = FindObjectOfType<SaveBetInfo>();
        string path = "Assets/SavedData/winningNumbers.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        foreach (int i in sBI.winNum)
        {
            writer.WriteLine(i + " ");
        }

        writer.WriteLine(-1);

        writer.Close();

        ReadString();
    }

    private void ReadString()
    {
        string path = "Assets/SavedData/winningNumbers.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log("Reader: " + reader.ReadToEnd());
        reader.Close();
    }

}
