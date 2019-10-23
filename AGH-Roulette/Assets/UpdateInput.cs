using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateInput : MonoBehaviour
{
    string input;
    public TMP_Text text;

    void Update()
    {
        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            input = GestureInputManager.CurrentInput.ToString();
            text.text = input;
        }
    }
}
