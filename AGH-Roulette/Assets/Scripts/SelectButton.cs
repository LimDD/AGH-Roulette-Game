using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    Button btn;

    public void SaveButton(Button b)
    {
        Debug.Log("SaveButtonMethod");

        btn = b;
    }

    public Button GetButton()
    {
        return btn;
    }
}
