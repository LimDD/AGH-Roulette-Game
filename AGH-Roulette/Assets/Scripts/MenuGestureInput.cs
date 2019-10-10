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

    public void SaveBtn(Button b)
    {
        btn = b;
    }

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
                btn.Select();
                aSG = btn.GetComponent<AudioSG>();
                aSG.HoverSound();
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
