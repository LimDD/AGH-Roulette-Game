using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuGestureInput : MonoBehaviour
{
    public Button easterEgg;
    Button btn;
    AudioSG aSG;
    SelectButton sB;

    void Update()
    {
        if (GestureInputManager.CurrentInput == InputAction.DoubleFingerDoubleTap)
        {
            easterEgg.onClick.Invoke();
        }

        else if (GestureInputManager.CurrentInput == InputAction.Click)
        {
            try
            {
                //Can not figure out how to select and read out button name on button click without interferring with double click anywhere
            }

            catch
            {
                Debug.Log("Error or back clicked");
            }
        }

        else if (GestureInputManager.CurrentInput == InputAction.DoubleClick)
        {
            try
            {
                sB = FindObjectOfType<SelectButton>();
                btn = sB.GetButton();

                if (btn != null)
                {
                    btn.onClick.Invoke();
                    EventSystem.current.SetSelectedGameObject(null);
                }
            }

            catch
            {

            }

        }
    }
}
