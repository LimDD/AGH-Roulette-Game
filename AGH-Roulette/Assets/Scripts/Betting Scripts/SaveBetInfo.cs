using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SaveBetInfo : MonoBehaviour
{
    private GetButtonNum gBN;
    private CornerandWallBets cAW; 
    public Button btn;
    public int num;
    public List<int> winNum = new List<int>();

    private void Awake()
    {
        string path = "/winningNumbers.txt";

        //Clears the file
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path);
        writer.Flush();
        writer.Close();
    }

    public void SaveBetType()
    {
        string str;

        //Gets the text/tmp component of the button and saves it to a string
        try
        {
            str = btn.GetComponentInChildren<TextMeshProUGUI>().text;
        }

        catch
        {
            str = btn.GetComponentInChildren<Text>().text;
        }

        //Remove New Lines in the string
        string type = Regex.Replace(str,"\n"," ");

        int.TryParse(type, out int single);

        //If the tryparse doesn't fail then single will be = to a number meaning it was a single number bet
        if (single != 0 || type == "0")
        {
            type = "Single Bet";
        }

        Debug.Log(type);

        //The only strings containing "Bet" are inside bets
        if (type.Contains("Bet"))
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

        //int num;

        //Zero does not have a zoom screen so it never uses the GetButtonNum script, so any errors must mean the bet on number was zero
        try
        {
            num = gBN.num;
        }

        catch
        {
            num = 0;
        }
        winNum.Add(num);
        //Get the name of the button to determine the numbers around it
        string name = EventSystem.current.currentSelectedGameObject.name;

        if (betType == "Split Bet")
        {
            switch (name)
            {
                case "TopMiddleButton":
                    if (num < 3)
                    {
                        winNum.Add(0);
                    }

                    else
                    {
                        winNum.Add(num - 3);
                    }
                    break;

                case "MiddleLeftButton":
                    winNum.Add(num - 1);
                    break;

                case "MiddleRightButton":
                    winNum.Add(num + 1);
                    break;
                case "BottomMiddleButton":
                    winNum.Add(num + 3);
                    break;
            }
        }

        else if (betType == "Corner Bet")
        {
            switch (name)
            {
                case "TopLeftButton":
                    winNum.Add(num - 1);
                    winNum.Add(num - 4);
                    winNum.Add(num - 3);
                    break;

                case "TopRightButton":
                    winNum.Add(num - 3);
                    winNum.Add(num - 2);
                    winNum.Add(num + 1);
                    break;

                case "BottomLeftButton":
                    winNum.Add(num + 2);
                    winNum.Add(num + 3);
                    winNum.Add(num - 1);
                    break;
                case "BottomRightButton":
                    winNum.Add(num + 1);
                    winNum.Add(num + 3);
                    winNum.Add(num + 4);
                    break;
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
        WriteToFile(betType);
    }

    public void WinningNumbersOutside(string betType)
    {
        //Get the name of the button to determine the numbers covered by the bet
        string name = EventSystem.current.currentSelectedGameObject.name;
        int calc = 0;

        if (name == "1st_Column" || name == "2nd_Column" || name == "3rd_Column")
        {
            switch (name)
            {
                case "1st_Column":
                    calc = -2;
                    break;

                case "2nd_Column":
                    calc = -1;
                    break;

                case "3rd_Column":
                    calc = 0;
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

                else if (i == 17 || i == 9 || i == 27)
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
                winNum.Add(i);
            }
        }
        WriteToFile(betType);
    }

    public void WriteToFile(string betType)
    {
        string path = "/winningNumbers.txt";

        //Write some text to the winningNumbers.txt file
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + path, true);

        writer.WriteLine(betType);
        foreach (int i in winNum)
        {
            writer.WriteLine(i);
        }
        writer.Close();
    }
}
