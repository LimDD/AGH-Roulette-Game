using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class GetButtonNum : MonoBehaviour
{
    public Text tNum;
    public Vector4 tNumColor;
    public Button topL;
    public Button topM;
    public Button topR;
    public Button midL;
    public Button midR;
    public Button botL;
    public Button botM;
    public Button botR;
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
        num = GetNumber();

        //Setting the number and color retreived from the roulette table button to the zoomed button
        tNum.text = System.Convert.ToString(num);
        GameObject.Find("Zoomed Button").GetComponent<Image>().color = buttonColor;
        BetType(num);
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
        topL.interactable = true;
        topM.interactable = true;
        topR.interactable = true;
        midL.interactable = true;
        midR.interactable = true;
        botL.interactable = true;
        botM.interactable = true;
        botR.interactable = true;

        topL.GetComponentInChildren<Text>().text = "Corner\nBet";
        topR.GetComponentInChildren<Text>().text = "Corner\nBet";
        midL.GetComponentInChildren<Text>().text = "Split\nBet";


        //Makes far right column inside bets unable to place a bet on the right side buttons
        for (int x = 1; x < 13; x++)
        {
            if (n == (3 * x))
            {
                botR.interactable = false;
                midR.interactable = false;
                topR.interactable = false;
                x = 14;
            }
        }

        for (int x = 0; x < 12; x++)
        {
            if (n == (1 + x * 3))
            {
                midL.GetComponentInChildren<Text>().text = "Street\nBet";
                botL.interactable = false;
                topL.interactable = false;
                x = 12;
            }
        }

        if (n <= 3 && n > 0)
        {
            topL.GetComponentInChildren<Text>().text = "Trio\nBet";
            topR.GetComponentInChildren<Text>().text = "Trio\nBet";
        }

        if (n >= 34)
        {
            botL.interactable = false;
            botM.interactable = false;
            botR.interactable = false;
        }
    }
}


