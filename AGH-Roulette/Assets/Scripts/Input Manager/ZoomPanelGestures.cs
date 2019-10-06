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


    private void Start()
    {
        height = Screen.height;
        bGI = FindObjectOfType<BoardGestureInput>();
        bTR = FindObjectOfType<BetTypeReader>();
    }

    public void SetButton(Button b)
    {
        btn = b;
    }

    public void Gestures(string type)
    {
        if (type == "DoubleClick")
        {
            btn.Select();
            btn.onClick.Invoke();
        }
    }
}
