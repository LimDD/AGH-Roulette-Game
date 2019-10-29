using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//Starts a timer to read out the amount the user is wanting to bet
public class BetPanelTimer : MonoBehaviour
{
    public TMP_Text amount;
    public TMP_Text bal;
    NumberReaderScript nRS;
    public float targetTime;
    public AudioSource narrator;
    bool finished;

    void Start()
    {
        nRS = FindObjectOfType<NumberReaderScript>();
    }

    public void CallTimer()
    {
        finished = false;
        targetTime = 0.8f;
    }

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f && targetTime > -1f && !finished)
        {
            if (!narrator.isPlaying)
            {
                TimerEnded();
                finished = true;
            }

            else
            {
                targetTime = 1f;
            }
        }
    }

    //If the user stays on the number long enough without changing
    void TimerEnded()
    {
        if (amount.isActiveAndEnabled)
        {
            Debug.Log("Timer Finished");
            int num = int.Parse(amount.text);

            nRS.SetNumber(num);
            nRS.ReadNumber();
        }
    }
}
