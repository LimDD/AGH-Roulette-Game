using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomPanelGestures : MonoBehaviour
{
    string btnName;
    bool first;
    float height;

    BoardGestureInput bGI;
    BetTypeReader bTR;

    public Button btn;


    private void Start()
    {
        height = Screen.height;
        btnName = "";
        first = true;
        bGI = FindObjectOfType<BoardGestureInput>();
        bTR = FindObjectOfType<BetTypeReader>();
    }

    public void Gestures(string type)
    {
        if (type == "DoubleClick")
        {
            btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            btn.onClick.Invoke();
        }
    }
}
