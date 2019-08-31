using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveBetInfo : MonoBehaviour
{
    public GetButtonNum gBN;
    public Button btn;
    public ArrayList betNums = new ArrayList();
    public ArrayList betTypes = new ArrayList();
    public ArrayList winNum = new ArrayList();

    private void Awake()
    {
        string path = "Assets/SavedData/winningNumbers.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);

        writer.Flush();
        writer.Close();
    }

    public void SaveBetType()
    {
        string str = "";
        str = btn.GetComponentInChildren<Text>().text;
        string type = Regex.Replace(str,"\n"," ");
        Debug.Log(type);
        betTypes.Add(type);

        if (str.Contains("Bet"))
        {
            WinningNumbers(type);
        }

        else
        {
            WinningNumbersOutside(type);
        }
    }

    //Gets the list of numbers the player can win on according to the number they chose and the type of bet
    //and saves it in winNum list
    public void WinningNumbers(string betType)
    {
        gBN = FindObjectOfType<GetButtonNum>();
        int num = gBN.num;
        betNums.Add(num);
        winNum.Add(num);

        string name = EventSystem.current.currentSelectedGameObject.name;

        if (betType == "Split Bet")
        {
            if (name == "TopMiddleButton")
            { 
                winNum.Add(num - 3);
            }

            else if (name == "MiddleLeftButton")
            {
                winNum.Add(num-1);
            }

            else if (name == "MiddleRightButton")
            {
                winNum.Add(num + 1);
            }

            else if (name == "BottomMiddleButton")
            {
                winNum.Add(num + 3);
            }
        }

        else if (betType == "Corner Bet")
        {
            if (name == "TopLeftButton")
            {
                winNum.Add(num-1);
                winNum.Add(num-4);
                winNum.Add(num-3);
            }

            else if (name == "TopRightButton")
            {
                winNum.Add(num-3);
                winNum.Add(num-2);
                winNum.Add(num+1);
            }

            else if (name == "BottomLeftButton")
            {
                winNum.Add(num+2);
                winNum.Add(num+3);
                winNum.Add(num-1);
            }

            else if (name == "BottomRightButton")
            {
                winNum.Add(num+1);
                winNum.Add(num+3);
                winNum.Add(num+4);
            }
        }

        else if (betType == "Street Bet")
        {
            winNum.Add(num + 1);
            winNum.Add(num + 2);
        }

        else if (betType == "Trio Bet")
        {
            if (num == 1)
            {
                winNum.Add(0);
                winNum.Add(2);
            }

            if (num == 2)
            {
                if (name == "TopLeftButton")
                {
                    winNum.Add(0);
                    winNum.Add(1);
                }

                else 
                {
                    winNum.Add(0);
                    winNum.Add(3);
                }
            }

            if (num == 3)
            {
                winNum.Add(0);
                winNum.Add(2);
            }
        }

        foreach (int i in winNum)
        {
            Debug.Log("winNum= "+ i);
        }
        WriteToFile();
    }

    public void WinningNumbersOutside(string betType)
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        int calc = 0;

        if (name == "1st_Column" || name == "2nd_Column" || name == "3rd_Column")
        {
            switch (name)
            {
                case "1st_Column":
                    calc = 1;
                    break;

                case "2nd_Column":
                    calc = 2;
                    break;

                case "3rd_Column":
                    calc = 3;
                    break;
            }

            for (int i = 0; i < 12; i++) 
            {
                calc += 3;
                winNum.Add(calc);
            }
        }

        else if (name == "1st_Third" || name == "2nd_Third" || name == "3rd_Third")
        {
            switch (name)
            {
                case "1st_Third":
                    calc = 1;
                    break;

                case "2nd_Third":
                    calc = 13;
                    break;

                case "3rd_Third":
                    calc = 25;
                    break;
            }

            for (int i = calc; i < calc + 12; i++)
            {
                winNum.Add(i);
            }
        }

        else if (name == "Evens" || name == "Odds")
        {
            switch (name)
            {
                case "Evens":
                    calc = 2;
                    break;

                case "Odds":
                    calc = 1;
                    break;
            }

            for (int i = calc; i < 36; i+=2)
            {
                winNum.Add(i);
            }
        }

        else if (name == "Reds" || name == "Blacks")
        {
            switch (name)
            {
                case "Reds":
                    calc = 2;
                    break;

                case "Blacks":
                    calc = 1;
                    break;
            }

            for (int i = calc; i <= 35; i +=2)
            {
                winNum.Add(i);

                if (i == 10 || i == 28 || i == 18)
                {
                    i--;
                }

                if (i == 17 || i == 9 || i == 27)
                {
                    i++;
                }
            }
        }

        else if (name == "1_To_18" || name == "19_To_36")
        {
            switch (name)
            {
                case "1_To_18":
                    calc = 1;
                    break;

                case "19_To_36":
                    calc = 19;
                    break;
            }

            for (int i = calc; i < calc + 18; i++)
            {
                winNum.Add(calc);
            }
        }

    }


    public void WriteToFile()
    {

        string path = "Assets/SavedData/winningNumbers.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        foreach (int i in winNum)
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
