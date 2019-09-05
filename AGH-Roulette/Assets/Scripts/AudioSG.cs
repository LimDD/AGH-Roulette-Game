using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;

public class AudioSG : MonoBehaviour, IPointerExitHandler
{
    public AudioSource source;
    public AudioClip hoverSound;
    public Button btn;
    public bool inFocus;

    void Start()
    {
        
    }

    public void HoverSound()
    {
        source.PlayOneShot(hoverSound);
    }

    public void CallTimer()
    {
        inFocus = true;
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.1f);

        //If the button is still in focus
        if (inFocus)
        {
            source.PlayOneShot(hoverSound);
        }
    }

    public void SetPitch()
    {
        string num = btn.GetComponentInChildren<TMP_Text>().text;

        float number = Int32.Parse(num);

        source.pitch = 1 + (number * 0.01f);

        HoverSound();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //If a button currently has the pointer on it
        if (inFocus)
        {
            source.Stop();
            inFocus = false;
        }
    }
}