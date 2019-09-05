using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using System;

public class GetButtonNum : MonoBehaviour
{
    public Text tNum;
    public Vector4 tNumColor;
    public Text topL;
    public Text topM;
    public Text topR;
    public Text midL;
    public Text midR;
    public Text botL;
    public Text botM;
    public Text botR;
    public int num;

    //GetNumAndColor
    //Gets the number and color of the button clicked on the board
    //Sets the number and color to the Zoomed Button on the Zoom Panel
    public void GetNumAndColor()
    {
        //Getting the current text of the zoomed button
        tNum = GameObject.Find("ZoomNum").GetComponent<Text>();
        tNumColor = GameObject.Find("Zoomed Button").GetComponent<Image>().color;

        //Getting the color of the button selected in the roulette table
        Vector4 buttonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;

        //Gets number from selected roulette cell
        int number = GetNumber();

        //Setting the number and color retreived from the roulette table button to the zoomed button
        tNum.text = Convert.ToString(number);
        GameObject.Find("Zoomed Button").GetComponent<Image>().color = buttonColor;
        num = Convert.ToInt32(number);
        BetType(num);

        Debug.Log("Color to set is: " + buttonColor);
        Debug.Log("Color of the zoomed button is: " + tNumColor);
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
        int num = Convert.ToInt32(strNum);

        return num;
    }

    public void BetType(int n)
    {
        topL = GameObject.Find("TopL").GetComponent<Text>();
        topM = GameObject.Find("TopM").GetComponent<Text>();
        topR = GameObject.Find("TopR").GetComponent<Text>();
        midL = GameObject.Find("MiddleL").GetComponent<Text>();
        midR = GameObject.Find("MiddleR").GetComponent<Text>();
        botL = GameObject.Find("BottomL").GetComponent<Text>();
        botM = GameObject.Find("BottomM").GetComponent<Text>();
        botR = GameObject.Find("BottomR").GetComponent<Text>();
        
        topL.GetComponentInParent<Button>().interactable = true;
        topM.GetComponentInParent<Button>().interactable = true;
        topR.GetComponentInParent<Button>().interactable = true;
        midL.GetComponentInParent<Button>().interactable = true;
        midR.GetComponentInParent<Button>().interactable = true;
        botL.GetComponentInParent<Button>().interactable = true;
        botM.GetComponentInParent<Button>().interactable = true;
        botR.GetComponentInParent<Button>().interactable = true;

        topL.text = "Corner\nBet";
        topR.text = "Corner\nBet";
        midL.text = "Split\nBet";


        //Makes far right column inside bets unable to place a bet on the right side buttons
        for (int x = 1; x < 13; x++)
        {
            if (n == (3 * x))
            {
                botR.GetComponentInParent<Button>().interactable = false;
                midR.GetComponentInParent<Button>().interactable = false;
                topR.GetComponentInParent<Button>().interactable = false;
                x = 14;
            }
        }

        for (int x = 0; x < 12; x++)
        {
            if (n == (1 + x * 3))
            {
                midL.text = "Street\nBet";
                botL.GetComponentInParent<Button>().interactable = false;
                topL.GetComponentInParent<Button>().interactable = false;
                x = 12;
            }
        }

        if (n <= 3 && n > 0)
        {
            topL.text = "Trio\nBet";
            topR.text = "Trio\nBet";
        }

        if (n >= 34)
        {
            botL.GetComponentInParent<Button>().interactable = false;
            botM.GetComponentInParent<Button>().interactable = false;
            botR.GetComponentInParent<Button>().interactable = false;
        }
    }
}


