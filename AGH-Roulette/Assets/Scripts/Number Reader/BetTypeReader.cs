using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BetTypeReader : MonoBehaviour, IPointerExitHandler
{
    public AudioSource source;
    public AudioSource narrator;
    public AudioClip[] clips;
    public Button btn;
    NumberReaderScript nRS;
    ZoomPanelGestures zPG;
    ClickButton cB;
    ReadBetNums rBN;
    List<int> numbers;
    public bool readType;
    string betType;
    string btnName;

    public void Start()
    {
        nRS = FindObjectOfType<NumberReaderScript>();
        rBN = FindObjectOfType<ReadBetNums>();
        zPG = FindObjectOfType<ZoomPanelGestures>();
        cB = FindObjectOfType<ClickButton>();
    }

    public void CallTimer()
    {
        zPG.SetButton(btn);
        readType = false;
        StartCoroutine(StartCountdown(0.7f));
    }

    public Button GetButton()
    {
        return btn;
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        if (!readType)
        {
            btn.Select();
            zPG.HoldSetButton(btn);
            BetType(btn);
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

            readType = false;
        }
    }

    public void BetType(Button b)
    {
        //Sets clip to single bet
        AudioClip myClip = clips[6];
        TMP_Text[] type;
        float time = 0f;

        source.panStereo = 0f;

        //Narrator only used in tutorial
        if (narrator == null || !narrator.isPlaying)
        {
            source.mute = false;
        }

        time = 0.8f;

        try
        {
            type = b.GetComponentsInChildren<TMP_Text>();
            betType = type[type.Length - 1].text;
            betType = Regex.Replace(betType, "\n", " ");
        }

        catch
        {
            
        }

        btnName = b.name;

        if (btnName.Contains("Left"))
        {
            source.panStereo = -0.6f;
        }

        else if (btnName.Contains("Right"))
        {
            source.panStereo = 0.6f;
        }

        //Sets the clip to be played according to the button selected
        if (btnName == "Top Left Number" || btnName == "Top Right Number" || btnName == "Bottom Left Number" || btnName == "Bottom Right Number")
        {
            switch (betType)
            {
                case "Corner Bet":
                    myClip = clips[0];
                    time = 0.8f;
                    break;

                case "Six Line Bet":
                    myClip = clips[1];
                    time = 1.1f;
                    break;

                case "Basket Bet":
                    myClip = clips[2];
                    time = 0.8f;
                    break;

                case "Trio Bet":
                    myClip = clips[3];
                    time = 0.8f;
                    break;
            }
        }

        else if (btnName == "Top Middle Number" || btnName == "Middle Left Number" || btnName == "Middle Right Number" || btnName == "Bottom Middle Number")
        {
            switch (betType)
            {
                case "Split Bet":
                    myClip = clips[4];
                    time = 0.8f;
                    break;

                case "Street Bet":
                    myClip = clips[5];
                    time = 0.8f;
                    break;
            }
        }

        source.clip = myClip;

        bool playing = true;

        if (source.isActiveAndEnabled)
        {
            while (playing)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                    playing = false;
                }
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
                case "Top Middle Number":
                    if (num < 3)
                    {
                        betNums.Add(0);
                    }

                    else
                    {
                        betNums.Add(num - 3);
                    }
                    break;

                case "Middle Left Number":
                    betNums.Add(num - 1);
                    break;

                case "Middle Right Number":
                    betNums.Add(num + 1);
                    break;
                case "Bottom Middle Number":
                    betNums.Add(num + 3);
                    break;
            }
        }

        else if (betType == "Corner Bet")
        {
            switch (btnName)
            {
                case "Top Left Number":
                    betNums.Add(num - 1);
                    betNums.Add(num - 4);
                    betNums.Add(num - 3);
                    break;

                case "Top Right Number":
                    betNums.Add(num - 3);
                    betNums.Add(num - 2);
                    betNums.Add(num + 1);
                    break;

                case "Bottom Left Number":
                    betNums.Add(num + 2);
                    betNums.Add(num + 3);
                    betNums.Add(num - 1);
                    break;
                case "Bottom Right Number":
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
                if (btnName == "Top Left Number")
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
            if (btnName == "Bottom Left Number")
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

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!readType)
        {
            StopAllCoroutines();
        }
    }
}

