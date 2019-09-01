using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RemoveBets : MonoBehaviour
{
    public void CancelledBet()
    {
        string path = "Assets/SavedData/winningNumbers.txt";

        //Clears the file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Delete");
        writer.Close();
    }
}
