using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CornerandWallBets : MonoBehaviour
{
    public int num;
    public Button btn;
    public Button btn2;
    public GameObject token;
    public GameObject table;
    public GetButtonNum gBN;

    //Gets the button number that was first clicked e.g 5 and the name of the button around the zoomed number e.g TopRightButton
    //To determine where the coin should go
    public void CoinPos()
    {
        gBN = FindObjectOfType<GetButtonNum>();

        //Gets the currently selected button which is one of the buttons around the zoomed number
        string name = EventSystem.current.currentSelectedGameObject.name;
        float x = 0;
        float y = 0;

        num = gBN.num;

        //If a trio bet between 2 and zero, then the coin should be placed between 0, 1, 2 or 0, 2, 3
        if (num == 2)
        {
            if (name == "TopRightButton")
            {
                num = 3;
            }

            else if (name == "TopLeftButton")
            {
                num = 1;
            }
        }

        //Sets the button
        btn = SetButton();

        //If a first column number was picked, check if it was a street bet
        if (num % 3 == 1 && name.Contains("LeftButton"))
        {
            btn2 = GameObject.Find("StreetCalc").GetComponent<Button>();

            if (name.Contains("Middle"))
            {
                y = btn.transform.position.y;
            }

            else
            {
                x = XMove();
                btn2 = null;

                if (name.Contains("Top"))
                {
                    num -= 3;
                }

                else
                {
                    num += 3;
                }
            }
        }

        else
        {
            //For most numbers this gets the second number the coin will be between
            switch (name)
            {
                case "TopLeftButton":
                    num -= 4;
                    break;
                case "TopMiddleButton":
                    num -= 3;
                    break;
                case "TopRightButton":
                    num -= 2;
                    break;
                case "MiddleLeftButton":
                    num--;
                    break;
                case "MiddleRightButton":
                    num++;
                    break;
                case "BottomLeftButton":
                    num += 2;
                    break;
                case "BottomMiddleButton":
                    num += 3;
                    break;
                case "BottomRightButton":
                    num += 4;
                    break;
            }
        }

        //For buttons 1_Cell 2_Cell 3_Cell since only 0 is in the row above is num is less than zero then zero must be the other number
        if (num <= 0)
        {
            num = 0;
            //Don't need to calculate x for split bets containing zero, just use the first buttons x value
            if (name == "TopMiddleButton")
            {
                x = btn.transform.position.x;
            }
        }

        //If not a street bet
        if (y == 0)
        {
            btn2 = SetButton();
            y = YMove();
        }

        if (x == 0)
        {
            x = XMove();
        }

        //Set the token position
        token.transform.position = new Vector2(x, y);
    }

    //Sets the buttons
    private Button SetButton()
    {
        string number = num.ToString();
        Button temp = GameObject.Find(number + "_Cell").GetComponent<Button>();
        return temp;
    }

    //Calculates the X value for the token to move to
    private float XMove()
    {
        float x = btn.transform.position.x;
        float x2 = btn2.transform.position.x;

        float tokenX = (x + x2) / 2;

        return tokenX;
    }

    //Calculates the Y value for the token to move to
    private float YMove()
    {
        float y = btn.transform.position.y;
        float y2 = btn2.transform.position.y;

        float tokenY = (y + y2) / 2;

        return tokenY;
    }
}
