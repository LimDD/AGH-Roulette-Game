using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpinResult : MonoBehaviour
{
    //public ArrayList betonNum = new ArrayList();
    public List<int> betonNum = new List<int>();
    public List<int> typeIndex = new List<int>();
    public List<string> betType = new List<string>();
    public RouletteWheelSpin rWS;
    public WinningsPayout wP;
    bool winner;

    private void Start()
    {
        rWS = FindObjectOfType<RouletteWheelSpin>();
        wP = FindObjectOfType<WinningsPayout>();
        winner = false;
    }

    //Checks if the result is the same
    public void CheckIfWinner()
    {
        string path = "Assets/SavedData/winningNumbers.txt";
        string line;
        string type = "";
        int saveNum;
        int count = 0;
        int betNum = 0;
        int numbers = 0;

        int winNum = rWS.rouletteValue;

        StreamReader reader = new StreamReader(path);

        //Add file data to betonNum list
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length <= 2)
            {
                saveNum = System.Convert.ToInt32(line);
                betonNum.Add(saveNum);
                if (numbers == 0)
                {
                    typeIndex.Add(betonNum.Count - 1);
                }

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
                        betonNum.RemoveAt(count - i - betNum - 1);
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
                int winIndex = betonNum.IndexOf(i);
                int smallest = 0;

                for (int j = 0; j < typeIndex.Count; j++)
                {
                    int temp = winIndex - typeIndex[j];

                    if (j == 0)
                    {
                        smallest = temp;
                    }

                    else if (temp < smallest && temp >= 0)
                    {
                        smallest = temp;
                        type = betType[j];

                    }
                }
                winner = true;
            }
        }

        if (winner)
        {
            //wP.GetWinnings(type);
            rWS.Winner(winNum);
        }
        else
        {
            rWS.Loser(winNum);
        }
    }
}
