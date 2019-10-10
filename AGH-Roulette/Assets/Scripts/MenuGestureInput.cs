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
                sB = FindObjectOfType<SelectButton>();
                btn = aSG.btn;
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

            btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
   
            if (btn != null)
            {
                btn.onClick.Invoke();
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }
}
