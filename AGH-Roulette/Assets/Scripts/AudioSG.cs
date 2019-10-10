﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioSG : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;
    public Button btn;

    public void HoverSound()
    {
        source.PlayOneShot(hoverSound);
    }


    public void CallTimer()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {

        yield return new WaitForSeconds(0.7f);

        source.Stop();
        source.PlayOneShot(hoverSound);

    }
}