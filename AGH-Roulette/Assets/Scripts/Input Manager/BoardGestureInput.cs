using UnityEngine;
using UnityEngine.EventSystems;

public class BoardGestureInput : MonoBehaviour
{
    public GameObject panel;
    public bool first;
    BetPanelTimer bPT;
    BettingGestures bG;
    RouletteBoardGestures rBG;
    ZoomPanelGestures zPG;
    PlayAgainGestures pAG;

    public void SetFirst()
    {
        first = false;
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

                else if (panel.name == "Portrait_Roulette_Table")
                {
                    rBG.Gestures(type);
                }

                else if (panel.name == "AnotherBetPanel")
                {
                    pAG.Gestures(type);
                }
            }
        }
    }
}
