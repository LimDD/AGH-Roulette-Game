using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomPanelGestures : MonoBehaviour
{
    float height;

    BoardGestureInput bGI;
    BetTypeReader bTR;

    Button btn;
    Button clickBtn;


    private void Start()
    {
        bGI = FindObjectOfType<BoardGestureInput>();
        bTR = FindObjectOfType<BetTypeReader>();
    }

    public void SetButton(Button b)
    {
        clickBtn = b;
    }

    public void HoldSetButton(Button b)
    {
        btn = b;
    }

    public void Gestures(string type)
    {
        if (type == "DoubleClick")
        {
            if (btn != null)
            {
                btn.Select();
                btn.onClick.Invoke();
            }
        }

        if (type == "Click")
        {
            Debug.Log(clickBtn.name);
            clickBtn.Select();
            bTR.readType = true;
            bTR.BetType(clickBtn);
        }
    }
}
