﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainGestures : MonoBehaviour
{
    public Button yes;
    public Button no;
    PlayRandomConfirmation pRC;

    public void Gestures(string type)
    {
        pRC = FindObjectOfType<PlayRandomConfirmation>();

        if (type == "SwipeUp")
        {
            if (yes != null)
            {
                yes.onClick.Invoke();
                pRC.SetHasPlayed();
            }
        }

        else if (type == "SwipeDown")
        {
            no.onClick.Invoke();
        }
    }
}
