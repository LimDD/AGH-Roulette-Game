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

        string name = EventSystem.current.currentSelectedGameObject.name;
        bool set = false;
        float x;
        float y;

        num = gBN.num;

        //If a trio bet between 2 and zero, then the coin should be between 0, 2 and either 1 or 3
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
        btn = SetButton(btn);

        //If a first column number was picked, check if it was a street bet
        for (int i = 0; i < 12; i++)
        {
            if (num == 1 + (i * 3))
            {
                if (name == "MiddleLeftButton")
                {
                    //Sets button 2 to 1st thrid to get its x value
                    btn2 = GameObject.Find("1st_Third").GetComponent<Button>();
                    set = true; 
                }
            }
        }

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

        //For buttons 1_Cell 2_Cell 3_Cell since only 0 is in the row above is num is less than zero then zero must be the other number
        if (num < 0)
        {
            num = 0;
        }

        //If button2 already set (If it was a street bet
        if (!set)
        {
            btn2 = SetButton(btn2);
        }

        //Don't need to calculate x for split bets containing zero, just use the first buttons x
        if (num == 0 && name == "TopMiddleButton")
        {
            x = btn.transform.position.x;
        }

        else
        {
            x = XMove();
        }

        //If not a street bet
        if (!set)
        {
            y = YMove();
        }

        //Just use the first buttons y value, no need to calculate
        else
        {
            y = btn.transform.position.y;
        }

        //Set the token position
        token.transform.position = new Vector2(x, y);
    }

    //Sets the buttons
    private Button SetButton(Button temp)
    {
        string number = num.ToString();
        temp = GameObject.Find(number + "_Cell").GetComponent<Button>();
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
