using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using TMPro;
using System.Collections.Generic;

public class GetButtonNum : MonoBehaviour
{
    public TMP_Text tNum;

    public Vector4 tNumColor;
    Vector4 GREEN = new Vector4(0.09f, 0.73f, 0.0f, 1.0f);
    Vector4 RED = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
    Vector4 BLACK = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

    public TMP_Text topL;
    public TMP_Text topM;
    public TMP_Text topR;
    public TMP_Text midL;
    public TMP_Text midR;
    public TMP_Text botL;
    public TMP_Text botM;
    public TMP_Text botR;

    public Button topLNum;
    public Button topMNum;
    public Button topRNum;
    public Button midLNum;
    public Button midRNum;
    public Button botLNum;
    public Button botMNum;
    public Button botRNum;

    public int num;

    List<int> REDNUMBERS = new List<int>()
    {
        1,
        3,
        5,
        7,
        9,
        12,
        14,
        16,
        18,
        19,
        21,
        23,
        25,
        27,
        30,
        32,
        34,
        36
    };

    List<int> BLACKNUMBERS = new List<int>()
    {
        2,
        4,
        6,
        8,
        10,
        11,
        13,
        15,
        17,
        20,
        22,
        24,
        26,
        28,
        29,
        31,
        33,
        35
    };

    //GetNumAndColor
    //Gets the number and color of the button clicked on the board
    //Sets the number and color to the Zoomed Button on the Zoom Panel
    public void GetNumAndColor()
    {
        //Getting the current text of the zoomed button
        tNum = GameObject.Find("ZoomNum").GetComponent<TMP_Text>();
        tNumColor = GameObject.Find("Zoomed Button").GetComponent<Image>().color;

        //Getting the color of the button selected in the roulette table
        Vector4 buttonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;

        //Gets number from selected roulette cell
        num = SetNumber();

        //Setting the number and color retreived from the roulette table button to the zoomed button
        tNum.text = System.Convert.ToString(num);
        GameObject.Find("Zoomed Button").GetComponent<Image>().color = buttonColor;
        BetType(num);
        SetSurroundingNum(num);
    }

    //GetNumber
    //Gets and returns the numbers from the name of the currently selected gameobject.
    //Returns as int.
    public int SetNumber()
    {
        //Gets the gameobject name of the pressed button as string.
        string name = EventSystem.current.currentSelectedGameObject.name;

        //Removes all non digit characters from string and saves as string.
        string strNum = Regex.Replace(name, "[^.0-9]", "");

        //Converts saved number string to type int.
        int num = System.Convert.ToInt32(strNum);

        return num;
    }

    public int GetNumber()
    {
        return num;
    }

    public void BetType(int n)
    {
        //Sets all buttons back to interactable if they werent already
        topLNum.gameObject.SetActive(true);
        topMNum.gameObject.SetActive(true);
        topRNum.gameObject.SetActive(true);
        midLNum.gameObject.SetActive(true);
        midRNum.gameObject.SetActive(true);
        botLNum.gameObject.SetActive(true);
        botMNum.gameObject.SetActive(true);
        botRNum.gameObject.SetActive(true);

        //Sets the button text back to default
        topL.text = "Corner\nBet";
        topR.text = "Corner\nBet";
        midL.text = "Split\nBet";
        botL.text = "Corner\nBet";
        botR.text = "Corner\nBet";

        //Makes far right column inside bets unable to place a bet on the right side buttons
        if (n % 3 == 0)
        {
            botR.gameObject.SetActive(false);
            midR.gameObject.SetActive(false);
            topR.gameObject.SetActive(false);

            botRNum.gameObject.SetActive(false);
            midRNum.gameObject.SetActive(false);
            topRNum.gameObject.SetActive(false);

        }

        //Makes left column left buttons names change for due to the different bets that can be made
        if (n % 3 == 1)
        {
            midL.text = "Street\nBet";
            botL.text = "Six Line\nBet";

            if (n == 1)
            {
                topL.text = "Basket\nBet";
                topR.text = "Trio\nBet";
            }

            else
            {
                topL.text = "Six Line\nBet";
            }
        }

        if (n == 3 || n == 2)
        {
            topL.text = "Trio\nBet";
            topR.text = "Trio\nBet";
        }

        //Bottom buttons on the bottom row cannot be played
        if (n >= 34)
        {
            botL.gameObject.SetActive(false);
            botM.gameObject.SetActive(false);
            botR.gameObject.SetActive(false);

            botLNum.gameObject.SetActive(false);
            botMNum.gameObject.SetActive(false);
            botRNum.gameObject.SetActive(false);
        }
    }

    public void SetSurroundingNum(int chosenNum)
    {
        Button btn = null;
        int num;
        bool inactive = false;

        string[] btnNames = { "Top Left Number", "Top Middle Number", "Top Right Number", "Middle Left Number", "Middle Right Number", "Bottom Left Number", "Bottom Middle Number", "Bottom Right Number"};

        for (int i = 0; i < 8; i++)
        {
            try
            {
                btn = GameObject.Find(btnNames[i]).GetComponent<Button>();
                inactive = false;
            }

            catch
            {
                inactive = true;
            }

            if (!inactive)
            {
                num = chosenNum - 4 + i;

                if (num < 0)
                {
                    num = 0;
                }

                if (num >= chosenNum)
                {
                    num++;
                }

                btn.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(num);
                SetColor(btn);
            }
        }

        if (chosenNum % 3 == 1)
        {
            topLNum.GetComponent<Image>().color = Color.clear;
            topLNum.GetComponentInChildren<TMP_Text>().text = "";
            midLNum.GetComponent<Image>().color = Color.clear;
            midLNum.GetComponentInChildren<TMP_Text>().text = "";
            botLNum.GetComponent<Image>().color = Color.clear;
            botLNum.GetComponentInChildren<TMP_Text>().text = "";

            if (chosenNum == 1)
            {
                topRNum.GetComponent<Image>().color = Color.clear;
                topRNum.GetComponentInChildren<TMP_Text>().text = "";
            }
        }

        if (chosenNum == 2 || chosenNum == 3)
        {
            topLNum.GetComponent<Image>().color = Color.clear;
            topLNum.GetComponentInChildren<TMP_Text>().text = "";

            topRNum.GetComponent<Image>().color = Color.clear;
            topRNum.GetComponentInChildren<TMP_Text>().text = "";
        }
    }

    public void SetColor(Button button)
    {

        if (button.GetComponentInChildren<TMP_Text>().text != "")
        {
            int buttonNumber = System.Convert.ToInt32(button.GetComponentInChildren<TMP_Text>().text);

            if (REDNUMBERS.Contains(buttonNumber))
            {
                button.GetComponent<Image>().color = RED;
            }
            else if (BLACKNUMBERS.Contains(buttonNumber))
            {
                button.GetComponent<Image>().color = BLACK;
            }
            else
            {
                button.GetComponent<Image>().color = GREEN;
            }
        }
    }
}


