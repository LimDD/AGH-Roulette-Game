using System.Collections;
using System.Collections.Generic;
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

    //public void CoinPos(string name, int n)
    public void CoinPos()
    {
        gBN = FindObjectOfType<GetButtonNum>();
        num = gBN.num;
        string name = EventSystem.current.currentSelectedGameObject.name;

        string number = num.ToString();
        btn = GameObject.Find(number + "_Cell").GetComponent<Button>();

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

        SetButton();

        float x = XMove();
        float y = YMove();

        token.transform.position = new Vector2(x, y);
    }

    public void SetButton()
    {
        string number = num.ToString();
        btn2 = GameObject.Find(number + "_Cell").GetComponent<Button>();
    }

    private float XMove()
    {
        float x = btn.transform.position.x;
        float x2 = btn2.transform.position.x;

        float tokenX = (x + x2) / 2;

        return tokenX;
    }

    private float YMove()
    {
        float y = btn.transform.position.y;
        float y2 = btn2.transform.position.y;

        float tokenY = (y + y2) / 2;

        return tokenY;
    }
}
