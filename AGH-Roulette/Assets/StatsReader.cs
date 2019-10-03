using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class StatsReader: MonoBehaviour
{
    public AudioSource source;
    public AudioSource narrator;
    public AudioSource numReader;
    public Text statName;
    public Text stat;
    public AudioClip clip1;
    public AudioClip clip2;
    NumberReaderScript nRS;

    public float time;
    bool read;
    private string btnName;
    private string num;

    private void Start()
    {
        nRS = FindObjectOfType<NumberReaderScript>();
    }

    public void CallTimer()
    {
        read = false;
        StartCoroutine(StartCountdown(0.2f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        if (!narrator.isPlaying)
        {
            if (!read)
            {
                read = true;

                if (statName.text.Contains("Losses"))
                {
                    source.PlayOneShot(clip2);
                }

                else
                {
                    source.PlayOneShot(clip1);
                }

                ReadStat();
            }

            else
            {
                num = stat.text;

                num = Regex.Replace(num, "[^0-9]", "");
                int n = int.Parse(num);
                nRS.SetNumber(n);
                numReader.Stop();
                numReader.mute = false;
                nRS.ReadNumber();
            }
        }
    }

    private void ReadStat()
    {
        time = 0.8f;
        StartCoroutine(StartCountdown(time));
    }

    
}

