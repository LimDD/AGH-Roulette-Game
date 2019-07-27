using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (InputManager.CurrentInput != InputAction.Null)
        {
            Debug.Log(InputManager.CurrentInput);
        }
    }
}
