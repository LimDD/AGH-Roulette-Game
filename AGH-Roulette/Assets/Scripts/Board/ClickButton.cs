using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    Button button;
    BoardButtonTimer bBT;
    bool changed;

    public void SetButton(Button btn)
    {
        button = btn;
        changed = true;
    }

    public void ButtonClicked()
    {
        bBT = FindObjectOfType<BoardButtonTimer>();

        //Won't play the sound again if you tap in blank space
        if (button != null && changed)  
        {
            bool inside = false;

            button.Select();

            if (button.name.Contains("_Cell"))
            {
                inside = true;
            }

            bBT.CountdownFinished(inside);
            changed = false;
        }
    }
}
