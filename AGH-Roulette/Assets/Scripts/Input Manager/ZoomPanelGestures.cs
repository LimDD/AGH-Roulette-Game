using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomPanelGestures : MonoBehaviour
{
    BoardGestureInput bGI;
    BetTypeReader bTR;

    Button btn;
    Button clickBtn;

    private void Start()
    {
        bGI = FindObjectOfType<BoardGestureInput>();
        bTR = FindObjectOfType<BetTypeReader>();
    }

    //Saves button for when button clicked
    public void SetButton(Button b)
    {
        clickBtn = b;
    }

    //Saves button when hovered for the time limit
    public void HoldSetButton(Button b)
    {
        btn = b;
    }

    public void Gestures(string type)
    {
        //Access Button
        if (type == "DoubleClick")
        {
            if (btn != null)
            {
                btn.Select();
                btn.onClick.Invoke();
            }
        }

        //Selects button
        if (type == "Click")
        {
            if (clickBtn != null)
            {
                Debug.Log("Zoom panel" + clickBtn.name);
                clickBtn.Select();
                btn = clickBtn;
                bTR.readType = true;
                bTR.BetType(clickBtn);
            }
        }
    }
}
