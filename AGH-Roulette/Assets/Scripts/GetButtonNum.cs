using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;


public class GetButtonNum : MonoBehaviour
{
    public Text tNum;
    public Text topL;
    public Text topM;
    public Text topR;
    public Text midL;
    public Text midR;
    public Text botL;
    public Text botM;
    public Text botR;

    public void GetNum()
    {
        tNum = GameObject.Find("ZoomNum").GetComponent<Text>();
        string name = EventSystem.current.currentSelectedGameObject.name;
        string number = Regex.Replace(name, "[^.0-9]", "");
        tNum.text = number;

        BetType(number);
    }

    public void BetType(string num)
    {
        topL = GameObject.Find("TopL").GetComponent<Text>();
        topM = GameObject.Find("TopL").GetComponent<Text>();
        topR = GameObject.Find("TopL").GetComponent<Text>();
        midL = GameObject.Find("MiddleL").GetComponent<Text>();
        midR = GameObject.Find("MiddleR").GetComponent<Text>();
        botL = GameObject.Find("BottomL").GetComponent<Text>();
        botM = GameObject.Find("BottomM").GetComponent<Text>();
        botR = GameObject.Find("BottomR").GetComponent<Text>();
        Debug.Log(num);
        if (num == "1")
        {
            Debug.Log("yep");
            botR.text = "Corner Bet";
        }
    }
}
