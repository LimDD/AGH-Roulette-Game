using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ExampleNumber : MonoBehaviour, IPointerExitHandler
{
    public NumberReader numberReader;
    public TMP_Text btnNum;
    bool inFocus;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ReadNumber()
    {
        inFocus = true;
        string num = btnNum.text;

        int.Parse(num);

        int numToRead = int.Parse(num);

        AudioClip[] clips = numberReader.GetNumberAudio(numToRead);

        for(int i= 0; i < clips.Length; i++)
        {
            audioSource.PlayOneShot(clips[i]);
            Debug.Log(clips[i].name);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //If a button currently has the pointer on it
        audioSource.Stop();
        inFocus = false;

    }

    public void CallTimer()
    {
        inFocus = true;
        StartCoroutine(StartCountdown(2f));
    }

    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        //If the button is still in focus
        if (inFocus)
        {
            ReadNumber();
        }
    }
}
