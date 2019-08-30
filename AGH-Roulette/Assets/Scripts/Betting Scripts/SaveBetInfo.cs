using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

    void Awake()
    {
        betNums.Clear();
        betTypes.Clear();
        winNum.Clear();
    }

    public void SaveBetType()
    {
        string str = btn.GetComponentInChildren<Text>().text;
        string type = Regex.Replace(str,"\n"," ");
        Debug.Log(type);
        betTypes.Add(type);
        WinningNumbers(type);
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
            Debug.Log(i + " ");
        }
    }
}
