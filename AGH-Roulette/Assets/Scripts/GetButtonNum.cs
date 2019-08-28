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
        topM = GameObject.Find("TopM").GetComponent<Text>();
        topR = GameObject.Find("TopR").GetComponent<Text>();
        midL = GameObject.Find("MiddleL").GetComponent<Text>();
        midR = GameObject.Find("MiddleR").GetComponent<Text>();
        botL = GameObject.Find("BottomL").GetComponent<Text>();
        botM = GameObject.Find("BottomM").GetComponent<Text>();
        botR = GameObject.Find("BottomR").GetComponent<Text>();
        int n = Convert.ToInt32(num);

        Debug.Log(n);
 
        for (int x = 0; x < 11; x++)
        {
            if (n == 3 *x)
            {
                //Commented these out for now as I do not know the best way to restore it after they have completed their bet.
                botR.GetComponentInParent<Button>().gameObject.SetActive(false);
                //botR.GetComponentInParent<Button>().interactable = false;
                x = 12;
            }
        }

        if (n <= 3)
        {
            topL.GetComponentInParent<Button>().gameObject.SetActive(false);
            topM.GetComponentInParent<Button>().gameObject.SetActive(false);
            topR.GetComponentInParent<Button>().gameObject.SetActive(false);

            if (n == 34)
            {
                midL.GetComponentInParent<Button>().gameObject.SetActive(false);
                topL.GetComponentInParent<Button>().gameObject.SetActive(false);
            }

            if (n == 36)
            {
                midR.GetComponentInParent<Button>().gameObject.SetActive(false);
                topR.GetComponentInParent<Button>().gameObject.SetActive(false);
            }
        }

        if (n >= 34)
        {
            botL.GetComponentInParent<Button>().gameObject.SetActive(false);
            botM.GetComponentInParent<Button>().gameObject.SetActive(false);
            botR.GetComponentInParent<Button>().gameObject.SetActive(false);

            if (n == 34)
            {
                midL.GetComponentInParent<Button>().gameObject.SetActive(false);
                topL.GetComponentInParent<Button>().gameObject.SetActive(false);
            }

            if (n== 36)
            {
                midR.GetComponentInParent<Button>().gameObject.SetActive(false);
                topR.GetComponentInParent<Button>().gameObject.SetActive(false);
            }
        }
    }
}


