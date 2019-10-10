using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioSG : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hoverSound;
    public Button btn;
    SelectButton sB;

    private void Start()
    {
        sB = FindObjectOfType<SelectButton>();
    }

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
        btn.Select();
        source.Stop();
        HoverSound();
        sB.SaveButton(btn);
        btn.Select();
    }
}