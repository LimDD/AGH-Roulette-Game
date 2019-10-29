using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelGestureInput : MonoBehaviour
{
    public TMP_Text balance;
    public Text text;
    public GameObject wheel;
    public GameObject summary;
    public GameObject completed;
    public AudioSource source;
    public AudioSource nums;

    SceneSwitcher sS;
    StatsReset sR;

    private void Start()
    {
        sS = FindObjectOfType<SceneSwitcher>();
        sR = FindObjectOfType<StatsReset>();
    }

    //Input for the wheel scene
    void Update()
    {
        if (GestureInputManager.CurrentInput != InputAction.Null)
        {
            string type = GestureInputManager.CurrentInput.ToString();

            Debug.Log(type);

            //Waits until the result text has been changed
            if (text.text != "")
            {
                if (type == "SwipeUp")
                {
                    sR.ClearSummary();

                    //If summary isn't null the player is not in the tutorial
                    if (summary != null)
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

                    else
                    {
                        if (completed.activeSelf)
                        {
                            sS.MenuScene();
                        }

                        else
                        {
                            wheel.SetActive(false);
                            completed.SetActive(true);
                        }
                    }
                }

                else if (type == "SwipeDown")
                {
                    sS.MenuScene();
                }

                //Show the round summary
                else if (type == "DoubleClick")
                {
                    if (wheel.activeSelf && summary != null)
                    {
                        wheel.SetActive(false);
                        summary.SetActive(true);
                    }
                }

                //Play the balance
                else if (type == "Click" && wheel.activeSelf && !source.isPlaying && !nums.isPlaying)
                {
                    balance.GetComponentInParent<Button>().onClick.Invoke();
                }
            }


        }
    }
}
