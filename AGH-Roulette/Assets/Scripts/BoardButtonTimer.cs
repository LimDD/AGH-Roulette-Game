using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardButtonTimer : MonoBehaviour, IPointerExitHandler
{
    ReadNumbers rN;
    AudioSource audioSource;
    public TMP_Text btnNum;
    bool inFocus;

    private void Start()
    {
        rN = FindObjectOfType<ReadNumbers>();
    }

    public void CallTimer()
    {
        inFocus = true;

        StartCoroutine(StartCountdown(0.6f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        string num = btnNum.text;
        yield return new WaitForSeconds(f);

        //If the button is still in focus
        if (inFocus)
        {
            inFocus = false;
            rN.ReadNumber(num);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //If the pointer has let the button
        inFocus = false;

    }
}
