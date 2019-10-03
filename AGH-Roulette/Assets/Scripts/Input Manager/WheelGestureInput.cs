using TMPro;
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

    private void Start()
    {
        sS = FindObjectOfType<SceneSwitcher>();
    }

    void Update()
    {
        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            string type = GestureInputManager.CurrentInput.ToString();

            Debug.Log(type);

            if (type == "DoubleClick" && text.text != "")
            {
                if (balance.text != "0")
                {
                    
                    sS.BoardScene();
                }

                else
                {
                    sS.MenuScene();
                }
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
