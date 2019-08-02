using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button button;
    public int coins;


    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");

        if (coins > 0)
        {
            coins--;
            Debug.Log("You have "+coins+" coins left.");
        }

        else
        {
            Debug.Log("Error, You are out of coins");
        }
    }
}

