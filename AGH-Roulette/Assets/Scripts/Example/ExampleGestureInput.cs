using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExampleGestureInput : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text amount;
    public TMP_Text balance;
    public Button confirm;
    bool first;
    BetPanelTimer bPT;
    // Update is called once per frame

    void Update()
    {
        if (!first)
        {
            bPT = panel.GetComponent<BetPanelTimer>();
            bPT.CallTimer();
            first = true;
        }

        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            string type = GestureInputManager.CurrentInput.ToString();

            Debug.Log(type);

            if (type == "DoubleClick")
            {
                if (balance.text != "0")
                {
                    first = false;
                    confirm.onClick.Invoke();
                }
            }
            
            if (type.Contains("Swipe"))
            {
                if (bPT == null)
                {
                    bPT = panel.GetComponent<BetPanelTimer>();
                }

                bPT.CallTimer();
                if (panel.activeSelf)
                {
                    string temp = Regex.Replace(balance.text, "[^.0-9]", "");

                    int am = int.Parse(amount.text);

                    int bal = int.Parse(temp);

                    if (type.Contains("Up"))
                    {
                        if (am + 100 <= bal)
                        {
                            am += 100;
                            
                        }

                        else
                        {
                            am = bal;
                        }

                        amount.text = am.ToString();
                    }

                    else if (type.Contains("Down"))
                    {
                        if (am - 100 >= 10)
                        {
                            am -= 100;
                            
                        }

                        else
                        {
                            am = 10;
                        }

                        amount.text = am.ToString();
                    }

                    else if (type.Contains("Left"))
                    {
                        if (am - 10 >= 10)
                        {
                            am -= 10;
                            amount.text = am.ToString();
                        }
                    }

                    else if (type.Contains("Right"))
                    {
                        if (am + 10 <= bal)
                        {
                            am += 10;
                            amount.text = am.ToString();
                        }
                    }
                }
            }
        }

        if (GestureInputManager.CurrentInput == InputAction.Click)
        {
            Debug.Log("The User has clicked");

            //TODO: Get the number of the selected cell, give that number to the number reader, read the number
        }
    }
}
