using System.Collections;
using System.Collections.Generic;
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

    public void GetNum()
    {
        //Getting the current text of the zoomed button
        tNum = GameObject.Find("ZoomNum").GetComponent<Text>();
        tNumColor = GameObject.Find("Zoomed Button").GetComponent<Image>().color;

        //Getting the color of the button selected in the roulette table
        Vector4 buttonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;

        //Getting the numbers from the name of the button selected by the user
        string name = EventSystem.current.currentSelectedGameObject.name;
        string number = Regex.Replace(name, "[^.0-9]", "");

        tNum.text = number;
        GameObject.Find("Zoomed Button").GetComponent<Image>().color = buttonColor;

        BetType(number);

        Debug.Log("Color to set is: " + buttonColor);
        Debug.Log("Color of the zoomed button is: " + tNumColor);
    }

 
    public void BetType(string num)
    {
        topL = GameObject.Find("TopL").GetComponent<Text>();
        topM = GameObject.Find("TopM").GetComponent<Text>();
        topR = GameObject.Find("TopR").GetComponent<Text>();
        midL = GameObject.Find("MiddleL").GetComponent<Text>();
        midR = GameObject.Find("MiddleR").GetComponent<Text>();
        botL = GameObject.Find("BottomL").GetComponent<Text>();
        botM = GameObject.Find("BottomM").GetComponent<Text>();
        botR = GameObject.Find("BottomR").GetComponent<Text>();

        int n = Convert.ToInt32(num);

        topL.GetComponentInParent<Button>().interactable = true;
        topM.GetComponentInParent<Button>().interactable = true;
        topR.GetComponentInParent<Button>().interactable = true;
        midL.GetComponentInParent<Button>().interactable = true;
        midR.GetComponentInParent<Button>().interactable = true;
        botL.GetComponentInParent<Button>().interactable = true;
        botM.GetComponentInParent<Button>().interactable = true;
        botR.GetComponentInParent<Button>().interactable = true;


        for (int x = 2; x < 12; x++)
        {
            if (n == 3 *x)
            {
                botR.GetComponentInParent<Button>().interactable = false;
                midR.GetComponentInParent<Button>().interactable = false;
                topR.GetComponentInParent<Button>().interactable = false;
                x = 12;
            }
        }

        for (int x = 0; x < 10; x++)
        {
            if (n == 4 + x *3)
            {
                botL.GetComponentInParent<Button>().interactable = false;
                midL.GetComponentInParent<Button>().interactable = false;
                topL.GetComponentInParent<Button>().interactable = false;
                x = 12;
            }
        }

        if (n <= 3 && n > 0)
        {
            topL.GetComponentInParent<Button>().interactable = false;
            topM.GetComponentInParent<Button>().interactable = false;
            topR.GetComponentInParent<Button>().interactable = false;

            if (n == 1)
            {
                midL.GetComponentInParent<Button>().interactable = false;
                botL.GetComponentInParent<Button>().interactable = false;
            }

            if (n == 3)
            {
                midR.GetComponentInParent<Button>().interactable = false;
                botR.GetComponentInParent<Button>().interactable = false;
            }
        }

        if (n >= 34)
        {
            botL.GetComponentInParent<Button>().interactable = false;
            botM.GetComponentInParent<Button>().interactable = false;
            botR.GetComponentInParent<Button>().interactable = false;

            if (n == 34)
            {
                midL.GetComponentInParent<Button>().interactable = false;
                topL.GetComponentInParent<Button>().interactable = false;
            }

            if (n== 36)
            {
                midR.GetComponentInParent<Button>().interactable = false;
                topR.GetComponentInParent<Button>().interactable = false;
            }
        }
    }
}


