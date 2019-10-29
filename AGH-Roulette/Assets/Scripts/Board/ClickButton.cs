using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Skips the timer to play the sound of the button clicked
public class ClickButton : MonoBehaviour
{
    Button button;
    BoardButtonTimer bBT;
    bool changed;

    //Saves the button on pointer enter
    public void SetButton(Button btn)
    {
        button = btn;
        changed = true;
    }

    //Skips straight to the method called after the countdown has finished if clicked
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

            bBT.inside = inside;

            bBT.CountdownFinished();
            changed = false;
        }
    }
}
