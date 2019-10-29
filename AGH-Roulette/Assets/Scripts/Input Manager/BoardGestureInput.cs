using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardGestureInput : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public bool first;
    BetPanelTimer bPT;
    BettingGestures bG;
    RouletteBoardGestures rBG;
    ZoomPanelGestures zPG;
    PlayAgainGestures pAG;
    ClickButton cB;
    public string type;

    public void SetFirst()
    {
        first = !first;
    }

    private void Start()
    {
        bG = panel.GetComponent<BettingGestures>();
        zPG = panel.GetComponent<ZoomPanelGestures>();
        rBG = FindObjectOfType<RouletteBoardGestures>();
        pAG = panel.GetComponent<PlayAgainGestures>();
    }

    void Update()
    {
        //Plays the value of the bet amount on open if the value isnt changed
        if (!first && panel.activeSelf)
        {
            if (panel.name == "Betting Coins Panel")
            {
                bPT = panel.GetComponent<BetPanelTimer>();
                bPT.CallTimer();
                first = true;
            }
        }

        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            type = GestureInputManager.CurrentInput.ToString();
            Debug.Log(type);

            //Finds out what panel the user is on to access the right gestures
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

                else if (panel.name == "Portrait_Roulette_Table")
                {
                    string current = "";

                    try
                    {
                        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                        current = EventSystem.current.currentSelectedGameObject.name;
                    }

                    catch
                    {

                    }

                    if (type == "Click" && current != "Board")
                    {
                        cB = FindObjectOfType<ClickButton>();
                        cB.ButtonClicked();
                    }

                    else
                    {
                        rBG.Gestures(type);
                    }
                }

                else if (panel.name == "AnotherBetPanel")
                {
                    pAG.Gestures(type);
                }

                else
                {
                    //For tutorial
                    if (type == "Click")
                    {
                        panel.SetActive(false);
                        panel2.SetActive(true);
                    }
                }
            }
        }
    }
}
