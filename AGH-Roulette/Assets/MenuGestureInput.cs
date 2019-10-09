using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGestureInput : MonoBehaviour
{
    public Button easterEgg;

    void Update()
    {
        if (GestureInputManager.CurrentInput == InputAction.FourFingerDoubleTap)
        {
            easterEgg.onClick.Invoke();
        }
    }
}
