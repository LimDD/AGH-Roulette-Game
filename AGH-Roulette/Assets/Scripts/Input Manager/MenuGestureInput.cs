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
    public AudioSource source;

    public void SaveBtn(Button b)
    {
        btn = b;
    }

    void Update()
    {
        //Plays the easter egg sound
        if (GestureInputManager.CurrentInput == InputAction.TrippleFingerDoubleTap || GestureInputManager.CurrentInput == InputAction.TrippleFingerPressed)
        {
            if (!source.isPlaying && source.isActiveAndEnabled)
            {
                easterEgg.onClick.Invoke();
            }
        }

        //Selects and plays the button name
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
                Debug.Log("no btn selected");
            }
        }

        //Access the selected buttons on click method
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
                    btn = null;
                }
            }

            catch
            {
                Debug.Log("Error");
            }

        }
    }
}
