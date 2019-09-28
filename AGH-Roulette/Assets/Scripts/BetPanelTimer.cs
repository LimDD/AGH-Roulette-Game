using TMPro;
using UnityEngine;

public class BetPanelTimer : MonoBehaviour
{
    public TMP_Text amount;
    public TMP_Text bal;
    NumberReaderScript nRS;
    public float targetTime;
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
            TimerEnded();
            finished = true;
        }

    }

    void TimerEnded()
    {
        int num = int.Parse(amount.text);
        nRS.SetNumber(num);
        nRS.ReadNumber();
    }
}
