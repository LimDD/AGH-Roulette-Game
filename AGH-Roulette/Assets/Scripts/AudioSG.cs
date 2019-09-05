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
        yield return new WaitForSeconds(0.5f);

        if (inFocus)
        {
            source.PlayOneShot(hoverSound);
        }
    }

    public void SetPitch()
    {

        Debug.Log(btn.GetComponentInChildren<TMP_Text>().text);
        string num = btn.GetComponentInChildren<TMP_Text>().text;

        float number = Int32.Parse(num);

        source.pitch = 1 + (number * 0.01f);

        HoverSound();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inFocus = false;
    }
}