using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;

public class BetTypeReader : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public Button btn;
    NumberReaderScript nRS;
    public float targetTime;
    bool inFocus;

    public void CallTimer()
    {
        StartCoroutine(StartCountdown(0.2f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);
        BetType();

    }

    private void BetType()
    {
        AudioClip myClip;

        myClip = clip1;

        string betType = btn.GetComponentInChildren<Text>().text;

        betType = Regex.Replace(betType, "\n", " ");
        string btnName = btn.name;

        if (btnName == "TopLeftButton" || btnName == "TopRightButton" || btnName == "BottomLeftButton" || btnName == "BottomRightButton")
        {
            switch (betType)
            {
                case "Corner Bet":
                    myClip = clip1;
                    break;

                case "Six Line Bet":
                    myClip = clip2;
                    break;

                case "Basket Bet":
                    myClip = clip4;
                    break;

                case "Trio Bet":
                    myClip = clip3;
                    break;
            }
        }

        else if (btnName == "TopMiddleButton" || btnName == "MiddleLeftButton" || btnName == "MiddleRightButton" || btnName == "BottomMiddleButton")
        {
            switch (betType)
            {
                case "Split Bet":
                    myClip = clip1;
                    break;

                case "Street Bet":
                    myClip = clip2;
                    break;
            }
        }
            source.clip = myClip;
            source.Play();
    }
}

