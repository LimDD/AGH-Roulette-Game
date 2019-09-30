using UnityEngine;
using UnityEngine.EventSystems;

public class BoardGestureInput : MonoBehaviour
{
    public GameObject panel;
    public bool first;
    BetPanelTimer bPT;
    BettingGestures bG;
    ZoomPanelGestures zPG;
    // Update is called once per frame

    public void SetFirst()
    {
        first = false;
    }

    private void Start()
    {
        bG = panel.GetComponent<BettingGestures>();
        zPG = panel.GetComponent<ZoomPanelGestures>();
    }

    void Update()
    {
        if (!first && panel.name == "Betting Coins Panel" && panel.activeSelf)
        {
            bPT = panel.GetComponent<BetPanelTimer>();
            bPT.CallTimer();
            first = true;
        }

        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            string type = GestureInputManager.CurrentInput.ToString();
            Debug.Log(type);

            if (panel.activeSelf)
            {
                if (panel.name == "Betting Coins Panel")
                {
                    bG.Gestures(type);
                }

                else if (panel.name == "Zoom Panel")
                {
                    zPG.Gestures(type);
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
