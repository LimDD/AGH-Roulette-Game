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

    public Button topL;
    public Button topM;
    public Button topR;
    public Button midL;
    public Button midR;
    public Button botL;
    public Button botM;
    public Button botR;

    public Button topLNum;
    public Button topMNum;
    public Button topRNum;
    public Button midLNum;
    public Button midRNum;
    public Button botLNum;
    public Button botMNum;
    public Button botRNum;

    public int num;

    public List<int> REDNUMBERS = new List<int>()
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
    public List<int> BLACKNUMBERS = new List<int>()
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
        num = GetNumber();

        //Setting the number and color retreived from the roulette table button to the zoomed button
        tNum.text = System.Convert.ToString(num);
        GameObject.Find("Zoomed Button").GetComponent<Image>().color = buttonColor;
        BetType(num);
        SetSurroundingNum(num);
    }

    //GetNumber
    //Gets and returns the numbers from the name of the currently selected gameobject.
    //Returns as int.
    public int GetNumber()
    {
        //Gets the gameobject name of the pressed button as string.
        string name = EventSystem.current.currentSelectedGameObject.name;

        //Removes all non digit characters from string and saves as string.
        string strNum = Regex.Replace(name, "[^.0-9]", "");

        //Converts saved number string to type int.
        int num = System.Convert.ToInt32(strNum);

        return num;
    }

    public void BetType(int n)
    {
        //Sets all buttons back to interactable if they werent already
        topL.gameObject.SetActive(true);
        topM.gameObject.SetActive(true);
        topR.gameObject.SetActive(true);
        midL.gameObject.SetActive(true);
        midR.gameObject.SetActive(true);
        botL.gameObject.SetActive(true);
        botM.gameObject.SetActive(true);
        botR.gameObject.SetActive(true);
        topLNum.gameObject.SetActive(true);
        topMNum.gameObject.SetActive(true);
        topRNum.gameObject.SetActive(true);
        midLNum.gameObject.SetActive(true);
        midRNum.gameObject.SetActive(true);
        botLNum.gameObject.SetActive(true);
        botMNum.gameObject.SetActive(true);
        botRNum.gameObject.SetActive(true);

        //Sets the button text back to default
        topL.GetComponentInChildren<Text>().text = "Corner\nBet";
        topR.GetComponentInChildren<Text>().text = "Corner\nBet";
        midL.GetComponentInChildren<Text>().text = "Split\nBet";
        botL.GetComponentInChildren<Text>().text = "Corner\nBet";

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
            midL.GetComponentInChildren<Text>().text = "Street\nBet";
            botL.GetComponentInChildren<Text>().text = "Six Line\nBet";
            topLNum.gameObject.SetActive(false);
            midLNum.gameObject.SetActive(false);
            botLNum.gameObject.SetActive(false);

            if (n == 1)
            {
                topL.GetComponentInChildren<Text>().text = "Basket\nBet";
                topR.GetComponentInChildren<Text>().text = "Trio\nBet";
                topLNum.gameObject.SetActive(false);
                midLNum.gameObject.SetActive(false);
                botLNum.gameObject.SetActive(false);
            }

            else
            {
                topL.GetComponentInChildren<Text>().text = "Six Line\nBet";
                topLNum.gameObject.SetActive(false);
                midLNum.gameObject.SetActive(false);
                botLNum.gameObject.SetActive(false);
            }
        }

        if (n == 3 || n == 2)
        {
            topL.GetComponentInChildren<Text>().text = "Trio\nBet";
            topR.GetComponentInChildren<Text>().text = "Trio\nBet";
            topLNum.gameObject.SetActive(false);

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
        int topLInt = chosenNum - 4;
        int topMInt = chosenNum - 3;
        int topRInt = chosenNum - 2;
        int midLInt = chosenNum - 1;
        int midRInt = chosenNum + 1;
        int botLInt = chosenNum + 2;
        int botMInt = chosenNum + 3;
        int botRInt = chosenNum + 4;

        if (topMInt < 0)
        {
            topMInt = 0;
            topLNum.gameObject.SetActive(false);
            topRNum.gameObject.SetActive(false);
        }

        topLNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(topLInt);
        topMNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(topMInt);
        topRNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(topRInt);
        midLNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(midLInt);
        midRNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(midRInt);
        botLNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(botLInt);
        botMNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(botMInt);
        botRNum.GetComponentInChildren<TMP_Text>().text = System.Convert.ToString(botRInt);

        SetColor(topLNum);
        SetColor(topMNum);
        SetColor(topRNum);
        SetColor(midLNum);
        SetColor(midRNum);
        SetColor(botLNum);
        SetColor(botMNum);
        SetColor(botRNum);
    }

    public void SetColor(Button button)
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


