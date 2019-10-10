using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class BetTypeReader : MonoBehaviour
{
    public AudioSource source;
    public AudioSource nums;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public Button btn;
    NumberReaderScript nRS;
    ZoomPanelGestures zPG;
    ReadBetNums rBN;
    List<int> numbers;
    bool readType;
    string betType;
    string btnName;

    public void Start()
    {
        nRS = FindObjectOfType<NumberReaderScript>();
        rBN = FindObjectOfType<ReadBetNums>();
        zPG = FindObjectOfType<ZoomPanelGestures>();
    }

    public void CallTimer()
    {
        readType = false;
        StartCoroutine(StartCountdown(0.7f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        if (!readType)
        {
            btn.Select();
            zPG.SetButton(btn);
            BetType();
            readType = true;
        }

        else
        {
            Button bNum = GameObject.Find("Zoomed Button").GetComponent<Button>();
            string num = bNum.GetComponentInChildren<TMP_Text>().text;
            int n = int.Parse(num);
            numbers = ReadNums(n);

            numbers.Sort();
            rBN.SetNumberList(numbers);
        }
    }

    private void BetType()
    {
        AudioClip myClip;
        float time = 0f;

        source.panStereo = 0f;

        myClip = clip1;
        time = 0.8f;

        try
        {
            betType = btn.GetComponentInChildren<TMP_Text>().text;
            betType = Regex.Replace(betType, "\n", " ");
        }

        catch
        {
            
        }

        btnName = btn.name;

        if (btnName.Contains("Left"))
        {
            source.panStereo = -0.6f;
        }

        else if (btnName.Contains("Right"))
        {
            source.panStereo = 0.6f;
        }

        if (btnName == "TopLeftButton" || btnName == "TopRightButton" || btnName == "BottomLeftButton" || btnName == "BottomRightButton")
        {
            switch (betType)
            {
                case "Corner Bet":
                    myClip = clip1;
                    time = 0.8f;
                    break;

                case "Six Line Bet":
                    myClip = clip2;
                    time = 1.1f;
                    break;

                case "Basket Bet":
                    myClip = clip4;
                    time = 0.8f;
                    break;

                case "Trio Bet":
                    myClip = clip3;
                    time = 0.8f;
                    break;
            }
        }

        else if (btnName == "TopMiddleButton" || btnName == "MiddleLeftButton" || btnName == "MiddleRightButton" || btnName == "BottomMiddleButton")
        {
            switch (betType)
            {
                case "Split Bet":
                    myClip = clip1;
                    time = 0.8f;
                    break;

                case "Street Bet":
                    myClip = clip2;
                    time = 0.8f;
                    break;
            }
        }

        source.clip = myClip;

        bool playing = true;

        if (nums.isPlaying)
        {
            nums.Stop();
        }

        while (playing)
        {
            if (!source.isPlaying)
            {
                source.Play();
                playing = false;
            }
        }
        StartCoroutine(StartCountdown(time));
    }

    private List<int> ReadNums(int num)
    {
        List<int> betNums = new List<int>();

        betNums.Add(num);

        if (betType == "Split Bet")
        {
            switch (btnName)
            {
                case "TopMiddleButton":
                    if (num < 3)
                    {
                        betNums.Add(0);
                    }

                    else
                    {
                        betNums.Add(num - 3);
                    }
                    break;

                case "MiddleLeftButton":
                    betNums.Add(num - 1);
                    break;

                case "MiddleRightButton":
                    betNums.Add(num + 1);
                    break;
                case "BottomMiddleButton":
                    betNums.Add(num + 3);
                    break;
            }
        }

        else if (betType == "Corner Bet")
        {
            switch (btnName)
            {
                case "TopLeftButton":
                    betNums.Add(num - 1);
                    betNums.Add(num - 4);
                    betNums.Add(num - 3);
                    break;

                case "TopRightButton":
                    betNums.Add(num - 3);
                    betNums.Add(num - 2);
                    betNums.Add(num + 1);
                    break;

                case "BottomLeftButton":
                    betNums.Add(num + 2);
                    betNums.Add(num + 3);
                    betNums.Add(num - 1);
                    break;
                case "BottomRightButton":
                    betNums.Add(num + 1);
                    betNums.Add(num + 3);
                    betNums.Add(num + 4);
                    break;
            }
        }

        else if (betType == "Street Bet")
        {
            betNums.Add(num + 1);
            betNums.Add(num + 2);
        }

        else if (betType == "Trio Bet")
        {
            if (num == 1)
            {
                betNums.Add(0);
                betNums.Add(2);
            }

            if (num == 2)
            {
                if (btnName == "TopLeftButton")
                {
                    betNums.Add(0);
                    betNums.Add(1);
                }

                else
                {
                    betNums.Add(0);
                    betNums.Add(3);
                }
            }

            if (num == 3)
            {
                betNums.Add(0);
                betNums.Add(2);
            }
        }

        else if (betType == "Six Line Bet")
        {
            if (btnName == "BottomLeftButton")
            {
                for (int i = 1; i < 6; i++)
                {
                    betNums.Add(num + i);
                }
            }

            else
            {
                betNums.Add(num - 3);
                betNums.Add(num - 2);
                betNums.Add(num - 1);
                betNums.Add(num + 1);
                betNums.Add(num + 2);
            }
        }

        else if (betType == "Basket Bet")
        {
            for (int i = 0; i < 4; i++)
            {
                if (i != 1)
                {
                    betNums.Add(i);
                }
            }
        }

        return betNums;
    }
}

