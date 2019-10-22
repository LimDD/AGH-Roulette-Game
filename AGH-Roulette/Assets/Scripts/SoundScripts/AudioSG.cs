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
    MenuGestureInput mGI;

    private void Start()
    {
        sB = FindObjectOfType<SelectButton>();
    }

    public void HoverSound()
    {
        btn.Select();

        if (source.isActiveAndEnabled)
        {
            source.PlayOneShot(hoverSound);
        }

        sB.SaveButton(btn);
    }

    public void CallTimer()
    {
        mGI = FindObjectOfType<MenuGestureInput>();
        mGI.SaveBtn(btn);
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.7f);
        source.Stop();
        HoverSound();

    }
}