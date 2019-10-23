using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BettingGestures : MonoBehaviour
{
    BetPanelTimer bPT;
    BoardGestureInput bGI;
    public TMP_Text amount;
    public TMP_Text balance;
    public AudioSource source;
    public AudioSource amountReader;
    public AudioSource narrator;
    public Button confirm;

    public void Gestures(string type)
    {
        if (type == "DoubleClick")
        {
            if (balance.text != "0")
            {
                if (source == null)
                {
                    bGI = FindObjectOfType<BoardGestureInput>();
                    bGI.SetFirst();
                    confirm.onClick.Invoke();
                }

                else
                {
                    if (amount.text == "100")
                    {
                        bGI = FindObjectOfType<BoardGestureInput>();
                        bGI.SetFirst();
                        confirm.onClick.Invoke();
                    }

                    else
                    {
                        if (!narrator.isPlaying)
                        {
                            source.Play();
                        }
                    }
                }
            }
        }

        else if (type == "Click")
        {
            if (!narrator.isPlaying && !amountReader.isPlaying)
            {
                balance.GetComponentInParent<Button>().onClick.Invoke();
            }
        }

        else if (type.Contains("Swipe"))
        {
            if (bPT == null)
            {
                bPT = gameObject.GetComponent<BetPanelTimer>();
            }

            bPT.CallTimer();

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


