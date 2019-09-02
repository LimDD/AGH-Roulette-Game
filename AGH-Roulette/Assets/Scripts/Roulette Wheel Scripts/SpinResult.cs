using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpinResult : MonoBehaviour
{
    public ArrayList betonNum = new ArrayList();
    public ArrayList betType = new ArrayList();
    public RouletteWheelSpin rWS;
    bool winner;

    private void Start()
    {
        rWS = FindObjectOfType<RouletteWheelSpin>();
        winner = false;
    }

    //Checks if the result is the same
    public void CheckIfWinner()
    {
        string path = "Assets/SavedData/winningNumbers.txt";
        string line;
        int saveNum;
        int count = 0;
        int betNum = 0;
        int numbers = 0;

        int winNum = rWS.rouletteValue;

        StreamReader reader = new StreamReader(path);

        //Add file data to betonNum array
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length <= 2)
            {
                saveNum = System.Convert.ToInt32(line);
                betonNum.Add(saveNum);
                numbers++;
            }

            else
            {
                if (line != "Delete")
                {
                    betType.Add(line);
                    betNum++;
                    numbers = 0;
                }

                else
                {
                    betType.RemoveAt(betNum - 1);
                    count--;

                    for (int i = 0; i < numbers; i++)
                    {
                        betonNum.RemoveAt(count - betNum - i);
                    }
                    count -= numbers;
                    count--;
                }
            }
            count++;
        }

        reader.Close();

        foreach (int i in betonNum)
        {
            if (i == winNum)
            {
                winner = true;
            }
        }

        if (winner)
        {
            rWS.Winner(winNum);
        }
        else
        {
            rWS.Loser(winNum);
        }

    }
}
