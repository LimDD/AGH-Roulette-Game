using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomPanelGestures : MonoBehaviour
{
    string findHalf;
    string btnName;
    bool first;

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
        findHalf = "";
        btnName = "";
        first = true;
    }

    public void Gestures(string type)
    {
        if (type == "Click" && !first)
        {
            float y = Input.mousePosition.y;
            float height = Screen.height;

            float half = height / 2;

            float mid = height / 10;

            if (y > half + mid)
            {
                findHalf = "top";
            }

            else if (y < half - mid)
            {
                findHalf = "bot";
            }

            else
            {
                btnName = zoom.name;
                zoom.Select();
                findHalf = "";
            }
        }

        else if (first)
        {
            first = false;
        }

        else if (type.Contains("Swipe"))
        {
            if (type.Contains("Up"))
            {
                btnName = topM.name;
                topM.Select();
                findHalf = "";
            }

            else if (type.Contains("Down"))
            {
                btnName = botM.name;
                botM.Select();
                findHalf = "";
            }

            else if (type.Contains("Left"))
            {
                if (findHalf == "top")
                {
                    btnName = topL.name;
                    topL.Select();
                }

                else if (findHalf == "bot")
                {
                    btnName = botL.name;
                    botL.Select();
                }

                else
                {
                    btnName = midL.name;
                    midL.Select();
                    findHalf = "";
                }
            }

            else if (type.Contains("Right"))
            {
                if (findHalf == "top")
                {
                    btnName = topR.name;
                    topR.Select();
                }

                else if (findHalf == "bot")
                {
                    btnName = botR.name;
                    botR.Select();
                }

                else
                {
                    btnName = midR.name;
                    midR.Select();
                    findHalf = "";
                }
            }
        }

        else if (type == "DoubleClick")
        {
            first = true;

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
                    EventSystem.current.SetSelectedGameObject(botR.gameObject);
                    zoom.onClick.Invoke();
                    break;

                default:
                    first = false;
                    break;
            }
        }
    }
}
