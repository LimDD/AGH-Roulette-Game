using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AudioSG : MonoBehaviour, IPointerExitHandler
{
    public AudioSource source;
    public AudioClip hoverSound;
    bool inFocus;


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
        yield return new WaitForSeconds(0.4f);

        //If the button is still in focus
        if (inFocus)
        {
            source.PlayOneShot(hoverSound);
        }
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