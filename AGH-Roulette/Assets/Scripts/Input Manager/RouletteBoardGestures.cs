using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RouletteBoardGestures : MonoBehaviour
{
    SelectButton sB;
    BoardGestureInput bGI;
    Button btn;

    private void Start()
    {
        sB = FindObjectOfType<SelectButton>();
        bGI = FindObjectOfType<BoardGestureInput>();
    }

    public void Gestures(string type)
    {
        btn = sB.GetButton();

        if (btn != null)
        {
            string btnName = btn.name;

            if (type == "Click")
            {
                if (btn != null)
                {
                    EventSystem.current.SetSelectedGameObject(btn.gameObject);
                    btn.onClick.Invoke();
                    btn = null;
                }
            }
        }
    }
}
