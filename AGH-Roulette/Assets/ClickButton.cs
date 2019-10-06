using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    Button button;

    public void SetButton(Button btn)
    {
        button = btn;
    }

    public void ButtonClicked()
    {
        if (button != null)
        {
            button.Select();
            button.onClick.Invoke();
        }
    }
}
