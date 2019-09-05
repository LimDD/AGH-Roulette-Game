using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleGestureInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            Debug.Log(GestureInputManager.CurrentInput);
        }

        if (GestureInputManager.CurrentInput == InputAction.Click)
        {
            Debug.Log("The User has clicked");

            //TODO: Get the number of the selected cell, give that number to the number reader, read the number
        }
    }
}
