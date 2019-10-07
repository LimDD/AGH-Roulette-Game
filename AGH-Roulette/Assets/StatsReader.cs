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
    Text stat;
    public AudioClip[] clips;
    public AudioClip clip;
    NumberReaderScript nRS;

    public float time;
    bool read;
    private string num;
    private string textName;

    private void Start()
    {
        nRS = FindObjectOfType<NumberReaderScript>();

        CallTimer();
    }

    public void CallTimer()
    {
        read = false;
        StartCoroutine(StartCountdown(1.2f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        int count = 0;
        yield return new WaitForSeconds(f);
        for (int i = 0; i < clips.Length * 2; i++)
        {
            if (!numReader.isPlaying)
            {
                if (!read)
                {
                    read = true;

                    switch (count)
                    {
                        case 0:
                            textName = "RoundsPlayed";
                            break;

                        case 1:
                            textName = "BetsMade";
                            break;

                        case 2:
                            textName = "AWon";
                            break;

                        case 3:
                            textName = "ALost";
                            break;

                        case 4:
                            textName = "Profit";
                            break;
                    }

                    statName = GameObject.Find(textName).GetComponent<Text>();

                    if (statName.text.Contains("Losses"))
                    {
                        source.PlayOneShot(clip);
                    }

                    else
                    {
                        source.PlayOneShot(clips[count]);
                    }

                    count++;
                    yield return new WaitForSeconds(0.8f);
                }

                else
                {
                    switch (count)
                    {
                        case 1:
                            textName = "RP";
                            break;

                        case 2:
                            textName = "BM";
                            break;

                        case 3:
                            textName = "AW";
                            break;

                        case 4:
                            textName = "AL";
                            break;

                        case 5:
                            textName = "Pt";
                            break;
                    }

                    stat = GameObject.Find(textName).GetComponent<Text>();
                    num = stat.text;

                    num = Regex.Replace(num, "[^0-9]", "");
                    int n = int.Parse(num);
                    nRS.SetNumber(n);
                    nRS.ReadNumber();


                    yield return new WaitForSeconds(0.4f);

                    read = false;
                }
            }

            else
            {
                yield return new WaitForSeconds(0.1f);
                i--;
            }  
        }
    }   
}

