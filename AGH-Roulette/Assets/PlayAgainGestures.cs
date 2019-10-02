using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainGestures : MonoBehaviour
{
    public Button yes;
    public Button no;

    public void Gestures(string type)
    {
        if (type == "SwipeUp")
        {
            yes.onClick.Invoke();
        }

        else if (type == "SwipeDown")
        {
            no.onClick.Invoke();
        }
    }
}
