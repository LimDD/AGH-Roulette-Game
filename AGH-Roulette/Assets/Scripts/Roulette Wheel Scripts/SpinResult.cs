using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SpinResult : MonoBehaviour
{
    public List<int> betonNum = new List<int>();
    public List<int> typeIndex = new List<int>();
    public List<int> winIndex = new List<int>();
    public List<string> betType = new List<string>();
    public List<string> type = new List<string>();
    public List<int> saveIndex = new List<int>();
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
        int saveNum;
        int count = 0;
        int betNum = 0;
        int numbers = 0;

        int winNum = rWS.rouletteValue;

        StreamReader reader = new StreamReader(path);

        //Add file data to betonNum list
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length <= 2 && line != "")
            {
                saveNum = System.Convert.ToInt32(line);
                betonNum.Add(saveNum);
                if (numbers == 0)
                {
                    typeIndex.Add(betonNum.Count - 1);
                }

                numbers++;
            }

            else if (line != "")
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
                winIndex.Add(betonNum.IndexOf(i));
                int smallest = 0;

                for (int j = 0; j < typeIndex.Count; j++)
                {
                    int temp = winIndex[winIndex.Count() - 1] - typeIndex[j];

                    if (j == 0)
                    {
                        smallest = temp;
                        type.Add(betType[0]);
                        saveIndex.Add(0);
                    }

                    else if (temp < smallest && temp >= 0)
                    {
                        smallest = temp;
                        type.Add(betType[j]);
                        saveIndex.Add(j);
                    }
                }
                winner = true;
            }
        }

        if (winner)
        {
            for (int i = 0; i < type.Count() - 1; i++)
            {
                wP.GetWinnings(type[i], saveIndex[i]);
            }
            rWS.Winner(winNum);
        }

        else
        {
            rWS.Loser(winNum);
        }
    }
}
