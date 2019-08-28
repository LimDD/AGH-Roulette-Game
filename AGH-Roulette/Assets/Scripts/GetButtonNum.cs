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
        botR = GameObject.Find("BottomR").GetComponent<Text>();
        int n = Convert.ToInt32(num);

        Debug.Log(n);
 
        for (int x = 0; x < 11; x++)
        {
            if (n == 3 * x || n >= 34)
            {
                //Commented these out for now as I do not know the best way to restore it after they have completed their bet.
                //botR.GetComponentInParent<Button>().gameObject.SetActive(false);
                //botR.GetComponentInParent<Button>().interactable = false;
            }
        }
    }
}


