using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSG : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;
    public Button btn;


    public void HoverSound()
    {
        source.PlayOneShot(hoverSound);
    }

    public void SetPitch()
    {

        Debug.Log(btn.GetComponentInChildren<TMP_Text>().text);
        string num = btn.GetComponentInChildren<TMP_Text>().text;

        float number = Int32.Parse(num);

        source.pitch = 1 + (number * 0.01f);

        HoverSound();
    }

}