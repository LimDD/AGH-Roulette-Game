using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelGestureInput : MonoBehaviour
{
    public TMP_Text balance;
    public Button newBet;
    public Text text;

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
                    SceneSwitcher sS = FindObjectOfType<SceneSwitcher>();
                    sS.BoardScene();
                }
            }
        }
    }
}
