using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetsOfRouletteRead : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public void CallTimer()
    {
        StartCoroutine(StartCountdown(0.4f));
    }

    private IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        ReadInfo();
    }

    //Reads all data in bets of roulette
    public void ReadInfo()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }

        source.PlayOneShot(clip);
    }
}
