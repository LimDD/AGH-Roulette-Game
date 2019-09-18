using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardButtonTimer : MonoBehaviour, IPointerExitHandler
{
    ReadNumbers rN;
    public AudioSource audioSource;
    public AudioClip sound;
    public TMP_Text btnNum;
    bool inFocus;
    bool inFocusO;
    string num;

    private void Start()
    {
        rN = FindObjectOfType<ReadNumbers>();
    }

    public void CallTimer()
    {
        inFocus = true;

        num = btnNum.text;
        StartCoroutine(StartCountdown(0.6f));
    }

    public void CallTimerOutside()
    {
        inFocusO = true;
        StartCoroutine(StartCountdown(0.6f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        //If the button is still in focus
        if (inFocus)
        {
            inFocus = false;
            rN.ReadNumber(num);
        }

        if (inFocusO)
        {
            inFocusO = false;
            audioSource.PlayOneShot(sound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //If the pointer has let the button
        inFocus = false;
        inFocusO = false;
    }
}
