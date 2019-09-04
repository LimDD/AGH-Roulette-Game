using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class SpinResult : MonoBehaviour
{
    public List<int> betonNum = new List<int>();    //Saves the numbers from a bet read in from the winningNumbers.txt file
    public List<int> typeIndex = new List<int>();   //Gets the index of the first number of a new bet in betonNum
    public List<int> winIndex = new List<int>();    //Gets the index of the winning number in betonNum
    public List<string> betType = new List<string>(); //Saves the bet type read in from the winningNumbers.txt file
    public List<string> type = new List<string>(); //Saves the name of the winning bet type from betType
    public List<int> saveIndex = new List<int>(); //Saves the index of the winning betType
    List<string> betInfo = new List<string>();  //Reads in the data from the balandamount.txt file
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
            //Checks if the line length is 2 or less meaning its a number e.g. 0 - 36
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
                //Gets the bet type name from the file
                if (line != "Delete")
                {
                    betType.Add(line);
                    betNum++;
                    numbers = 0;
                }

                //Delete is added to the file when the back button is pressed when the user has already selected an outside bet or the bet type of the inside bet
                //This removes the bet they didn't confirm
                else
                {
                    betType.RemoveAt(betNum - 1);
                    count--;

                    for (int i = 0; i < numbers; i++)
                    {
                        betonNum.RemoveAt(count - i - betNum);
                    }
                    count -= numbers;
                    count--;
                }
            }
            count++;
        }

        reader.Close();

        count = 0;

        //Loops through the values in betonNum to check if it contains the winning number
        foreach (int i in betonNum)
        {
            if (i == winNum)
            {
                //Saves the index of the winning number inside the betonNum list
                winIndex.Add(betonNum.IndexOf(i));
                int smallest = 0;

                //Finds the bet type related to the winning number by comparing indexes of the winning number to the
                //index of the first number for the new bet, the closest index means it must be from that bet type

                for (int j = 0; j < typeIndex.Count; j++)
                {
                    int placeHolder = winIndex[winIndex.Count() - 1] - typeIndex[j];

                    //If its the first loop then save the values
                    if (j == 0)
                    {
                        smallest = placeHolder;
                        //If there is more than 1 bet that covers the winning number then count will have increased meaning the next bettype in the list is saved
                        type.Add(betType[count]);
                        saveIndex.Add(0);
                    }

                    //Checks if the smallest bettype index is smaller than the next index
                    else if (placeHolder < smallest && placeHolder >= 0)
                    {
                        smallest = placeHolder;
                        type.Add(betType[j]);
                        saveIndex.Add(j);
                    }
                }
                //If the winning number was found
                winner = true;
                count++;
            }
        }

        path = "Assets/SavedData/balandamount.txt";
        reader = new StreamReader(path);

        count = 0;
        //Add the balance and bet amount to betInfo
        while ((line = reader.ReadLine()) != null)
        {
            betInfo.Add(line);
            count++;
        }

        reader.Close();

        string bal = betInfo[count - 2];

        //Get back only the numbers in bal
        bal = Regex.Replace(bal, "[^0-9.]", "");

        int balance = System.Int32.Parse(bal);


        if (winner)
        {
            //Loops for each time the winning number was found
            for (int i = 0; i < type.Count(); i++)
            {
                System.Int32.TryParse(betInfo[saveIndex[i] + 2], out int amount);
                balance = wP.GetWinnings(type[i], balance, amount);
            }

            rWS.Winner(winNum);
            wP.ResetFile(balance);
        }

        else
        {
            rWS.Loser(winNum);
            wP.ResetFile(balance);
        }
    }
}
