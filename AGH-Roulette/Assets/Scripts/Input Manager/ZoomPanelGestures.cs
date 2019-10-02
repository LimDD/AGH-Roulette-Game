using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomPanelGestures : MonoBehaviour
{
    string btnName;
    bool first;
    float height;

    BoardGestureInput bGI;

    public Button topL;
    public Button topM;
    public Button topR;
    public Button midL;
    public Button midR;
    public Button botL;
    public Button botM;
    public Button botR;
    public Button zoom;

    private void Start()
    {
        height = Screen.height;
        btnName = "";
        first = true;
        bGI = FindObjectOfType<BoardGestureInput>();
    }

    public void Gestures(string type)
    {
        if (type == "Click")
        {
            btnName = zoom.name;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            zoom.Select();
        }

        if (type.Contains("Swipe"))
        {
            if (type.Contains("Up"))
            {
                if (topM.IsActive())
                {
                    btnName = topM.name;
                    topM.Select();
                }
            }

            else if (type.Contains("Down"))
            {
                if (botM.IsActive())
                {
                    btnName = botM.name;
                    botM.Select();
                }
            }

            else if (type.Contains("Left"))
            {
                if (midL.IsActive())
                {
                    btnName = midL.name;
                    midL.Select();
                }
            }

            else if (type.Contains("Right"))
            {
                if (midR.IsActive())
                {
                    btnName = midR.name;
                    midR.Select();
                }
            }

            else if (type.Contains("Diag"))
            {
                if (type.Contains("UL"))
                {
                    if (topL.IsActive())
                    {
                        btnName = topL.name;
                        topL.Select();
                    }
                }

                else if (type.Contains("UR"))
                {
                    if (topR.IsActive())
                    {
                        btnName = topR.name;
                        topR.Select();
                    }
                }

                else if (type.Contains("DL"))
                {
                    if (botL.IsActive())
                    {
                        btnName = botL.name;
                        botL.Select();
                    }
                }

                else if (type.Contains("DR"))
                {
                    if (botR.IsActive())
                    {
                        btnName = botR.name;
                        botR.Select();
                    }
                }
            }
        }

        else if (type == "DoubleClick")
        {
            switch (btnName)
            {
                case "TopLeftButton":
                    EventSystem.current.SetSelectedGameObject(topL.gameObject);
                    topL.onClick.Invoke();
                    break;

                case "TopMiddleButton":
                    EventSystem.current.SetSelectedGameObject(topM.gameObject);
                    topM.onClick.Invoke();
                    break;

                case "TopRightButton":
                    EventSystem.current.SetSelectedGameObject(topR.gameObject);
                    topR.onClick.Invoke();
                    break;

                case "MiddleLeftButton":
                    EventSystem.current.SetSelectedGameObject(midL.gameObject);
                    midL.onClick.Invoke();
                    break;

                case "MiddleRightButton":
                    EventSystem.current.SetSelectedGameObject(midR.gameObject);
                    midR.onClick.Invoke();
                    break;

                case "BottomLeftButton":
                    EventSystem.current.SetSelectedGameObject(botL.gameObject);
                    botL.onClick.Invoke();
                    break;

                case "BottomMiddleButton":
                    EventSystem.current.SetSelectedGameObject(botM.gameObject);
                    botM.onClick.Invoke();
                    break;

                case "BottomRightButton":
                    EventSystem.current.SetSelectedGameObject(botR.gameObject);
                    botR.onClick.Invoke();
                    break;

                case "Zoomed Button":
                    EventSystem.current.SetSelectedGameObject(zoom.gameObject);
                    zoom.onClick.Invoke();
                    break;

                default:
                    first = false;
                    break;
            }
        }
    }
}
