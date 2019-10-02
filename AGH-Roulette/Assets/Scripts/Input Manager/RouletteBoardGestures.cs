using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RouletteBoardGestures : MonoBehaviour
{
    public Button btn;

    public void Gestures(string type)
    {
        string btnName = btn.name;

        if (type == "DoubleClick")
        {

            switch (btnName)
            {
                case "TopLeftButton":
                    EventSystem.current.SetSelectedGameObject(btn.gameObject);
                    btn.onClick.Invoke();
                    break;
            }
        }
    }
}
