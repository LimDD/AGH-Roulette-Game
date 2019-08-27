using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class GetButtonNum : MonoBehaviour
{
    public Text tNum;

    public void GetNum()
    {
        tNum = GameObject.Find("ZoomNum").GetComponent<Text>();
        string name = EventSystem.current.currentSelectedGameObject.name;
        string newString = Regex.Replace(name, "[^.0-9]", "");
        tNum.text = newString;
    }
}
