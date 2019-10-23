using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    Button button;
    BoardButtonTimer bBT;

    public void SetButton(Button btn)
    {
        button = btn;
    }

    public void ButtonClicked()
    {
        bBT = FindObjectOfType<BoardButtonTimer>();

        if (button != null)
        {
            bool inside = false;

            button.Select();

            if (button.name.Contains("_Cell"))
            {
                inside = true;
            }

            bBT.CountdownFinished(inside);
        }
    }
}
