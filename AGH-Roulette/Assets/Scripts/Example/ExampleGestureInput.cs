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
    }
}
