﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelGestureInput : MonoBehaviour
{
    public TMP_Text balance;
    public Button newBet;
    public Text text;
    public GameObject wheel;
    public GameObject summary;

    SceneSwitcher sS;
    StatsReset sR;

    private void Start()
    {
        sS = FindObjectOfType<SceneSwitcher>();
        sR = FindObjectOfType<StatsReset>();
    }

    void Update()
    {
        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            string type = GestureInputManager.CurrentInput.ToString();

            Debug.Log(type);

            if (text.text != "")
            {
                if (type == "SwipeUp")
                {
                    sR.ClearSummary();
                    if (balance.text != "0")
                    {
                        sS.BoardScene();
                    }

                    else
                    {
                        sS.MenuScene();
                    }
                }
            }

            else if (type == "SwipeDown")
            {
                sS.MenuScene();
            }

            else if (type == "Click" && text.text != "")
            {
                if (wheel.activeSelf)
                {
                    wheel.SetActive(false);
                    summary.SetActive(true);
                }
            }
        }
    }
}
