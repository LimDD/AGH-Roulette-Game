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
        //Sets all buttons back to interactable if they werent already
        topL.gameObject.SetActive(true);
        topM.gameObject.SetActive(true);
        topR.gameObject.SetActive(true);
        midL.gameObject.SetActive(true);
        midR.gameObject.SetActive(true);
        botL.gameObject.SetActive(true);
        botM.gameObject.SetActive(true);
        botR.gameObject.SetActive(true);

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
        }

        //Makes left column left buttons names change for due to the different bets that can be made
        if (n % 3 == 1)
        {
            midL.GetComponentInChildren<Text>().text = "Street\nBet";
            botL.GetComponentInChildren<Text>().text = "Six Line\nBet";

            if (n == 1)
            {
                topL.GetComponentInChildren<Text>().text = "Basket\nBet";
                topR.GetComponentInChildren<Text>().text = "Trio\nBet";
            }

            else
            {
                topL.GetComponentInChildren<Text>().text = "Six Line\nBet";
            }
        }

        if (n == 3 || n == 2)
        {
            topL.GetComponentInChildren<Text>().text = "Trio\nBet";
            topR.GetComponentInChildren<Text>().text = "Trio\nBet";
        }

        //Bottom buttons on the bottom row cannot be played
        if (n >= 34)
        {
            botL.gameObject.SetActive(false);
            botM.gameObject.SetActive(false);
            botR.gameObject.SetActive(false);
        }
    }
}


