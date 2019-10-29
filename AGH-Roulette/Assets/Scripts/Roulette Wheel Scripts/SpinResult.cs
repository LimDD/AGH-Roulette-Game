using System.Collections;
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
    NumberReaderScript nRS;
    SaveBetInfo sBI;
    DontDestroy dD;
    public AudioSource source;
    public AudioSource nums;
    public AudioClip red;
    public AudioClip black;
    public AudioClip[] win;
    public AudioClip[] lose;
    public AudioClip controls;

    bool colourRed;
    public bool tutorial;
    bool winner;
    public int soundCount;

    private void Start()
    {
        rWS = FindObjectOfType<RouletteWheelSpin>();
        wP = FindObjectOfType<WinningsPayout>();
        nRS = FindObjectOfType<NumberReaderScript>();
        sBI = FindObjectOfType<SaveBetInfo>();
        dD = FindObjectOfType<DontDestroy>();
        winner = false;
        soundCount = 3;
    }

    //Plays the winning/losing messages
    private void Update()
    {
        if (!nums.isPlaying)
        {
            while (soundCount < 3 && !source.isPlaying)
            {
                switch (soundCount)
                {
                    case 0:
                        if (colourRed)
                        {
                            source.PlayOneShot(red);
                        }

                        else
                        {
                            source.PlayOneShot(black);
                        }
                        StartCoroutine(Delay());
                        break;

                    case 1:

                        int rand = Random.Range(0, 2);

                        if (winner)
                        {
                            source.PlayOneShot(win[rand]);
                        }

                        else
                        {
                            source.PlayOneShot(lose[rand]);
                        }
                        break;

                    case 2:
                        if (controls != null)
                        {
                            source.PlayOneShot(controls);
                        }
                        break;
                }

                soundCount++;
            }
        } 
    }
    //Checks if the result is the same
    public void CheckWinner()
    {
        List<string> betNums = sBI.GetSavedNums();
        string line;
        int saveNum;
        int count = 0;
        int betNum = 0;
        int numbers = 0;

        int winNum = rWS.rouletteValue;

        //Add file data to betonNum list
        foreach (string s in betNums)
        {
            //Checks if the line length is 2 or less meaning its a number e.g. 0 - 36
            if (s.Length <= 2)
            {
                saveNum = int.Parse(s);
                betonNum.Add(saveNum);
                if (numbers == 0)
                {
                    typeIndex.Add(betonNum.Count - 1);
                }

                numbers++;
            }

            //Gets the bet type name from the file
            else
            {
                betType.Add(s);
                betNum++;
                numbers = 0;
            }
            count++;
        }

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
                        type.Add("");
                        type[count] = (betType[count]);
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

        string path = "/balandamount.txt";
        StreamReader reader = new StreamReader(Application.persistentDataPath + path);

        count = 0;
        //Add the balance and bet amount to betInfo
        while ((line = reader.ReadLine()) != null)
        {
            betInfo.Add(line);
            count++;
        }

        reader.Close();

        string bal = betInfo[count - 2];
        string lastAmount = betInfo[count - 1];

        //Get back only the numbers in bal
        bal = Regex.Replace(bal, "[^0-9.]", "");

        int balance = int.Parse(bal);

        nRS.SetNumber(winNum);
        nRS.ReadNumber();

        colourRed = nRS.SetColour(winNum);

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

            if (!tutorial)
            {
                wP.ResetFile(balance);
            }

            else
            {
                wP.SetBal(balance);
            }
        }

        //If they lost
        else
        {
            rWS.Loser(winNum);
            wP.SetBal(balance);
        }

        dD.Destroy();

        soundCount = 0;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
    }

}
