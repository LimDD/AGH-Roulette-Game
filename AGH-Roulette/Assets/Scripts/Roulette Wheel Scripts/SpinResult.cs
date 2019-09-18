using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class SpinResult : MonoBehaviour
{
    List<int> betonNum = new List<int>();    //Saves the numbers from a bet read in from the winningNumbers.txt file
    List<int> typeIndex = new List<int>();   //Gets the index of the first number of a new bet in betonNum
    List<int> winIndex = new List<int>();    //Gets the index of the winning number in betonNum
    List<string> betType = new List<string>(); //Saves the bet type read in from the winningNumbers.txt file
    List<string> type = new List<string>(); //Saves the name of the winning bet type from betType
    List<int> saveIndex = new List<int>(); //Saves the index of the winning betType
    List<string> betInfo = new List<string>();  //Reads in the data from the balandamount.txt file
    RouletteWheelSpin rWS;
    WinningsPayout wP;
    ReadNumbers rN;
    bool winner;

    private void Start()
    {
        rWS = FindObjectOfType<RouletteWheelSpin>();
        wP = FindObjectOfType<WinningsPayout>();
        rN = FindObjectOfType<ReadNumbers>();
        winner = false;
    }

    //Checks if the result is the same
    public void CheckIfWinner()
    {
        string path = "/winningNumbers.txt";
        string line;
        int saveNum;
        int count = 0;
        int betNum = 0;
        int numbers = 0;

        int winNum = rWS.rouletteValue;

        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        //Add file data to betonNum list
        while ((line = reader.ReadLine()) != null)
        {
            //Checks if the line length is 2 or less meaning its a number e.g. 0 - 36
            if (line.Length <= 2 && line != "")
            {
                saveNum = int.Parse(line);
                betonNum.Add(saveNum);
                if (numbers == 0)
                {
                    typeIndex.Add(betonNum.Count - 1);
                }

                numbers++;
            }

            //Gets the bet type name from the file
            else if (line != "")
            {
                betType.Add(line);
                betNum++;
                numbers = 0;
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

        path = "/balandamount.txt";
        reader = new StreamReader(Application.persistentDataPath + path);

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

        int balance = int.Parse(bal);

        rN.ReadNumber(winNum.ToString());
        //If the player won
        if (winner)
        {
            //Loops for each time the winning number was found
            for (int i = 0; i < type.Count(); i++)
            {
                int.TryParse(betInfo[saveIndex[i] + 2], out int amount);
                balance = wP.GetWinnings(type[i], balance, amount);
            }

            rWS.Winner(winNum);
            wP.ResetFile(balance);
        }

        //If they lost
        else
        {
            rWS.Loser(winNum);
            wP.ResetFile(balance);
        }
    }
}
