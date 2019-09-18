using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ReadNumbers : MonoBehaviour, IPointerExitHandler
{
    public NumberReader numberReader;
    public TMP_Text btnNum;
    bool inFocus;
    bool playing;
    int numToRead;

    AudioSource audioSource;

    private void Awake()
    {
        numToRead = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void ReadNumber()
    {
        playing = true;
        string num = btnNum.text;

        int.Parse(num);

        numToRead = int.Parse(num);

        AudioClip[] clips = numberReader.GetNumberAudio(numToRead);

        for(int i= 0; i < clips.Length; i++)
        {
            StartCoroutine(ClipDelay(clips[i], i));
            Debug.Log(clips[i].name);
        }
    }

    public void CallTimer()
    {
        inFocus = true;
        playing = false;

        StartCoroutine(StartCountdown(0.6f));

    }

    //If the there is more than 1 clip add a delay between them
    public IEnumerator ClipDelay(AudioClip clip, int count)
    {
        if (count > 0)
        {
            yield return new WaitForSeconds(0.4f * count);
        }

        audioSource.pitch = 1f;
        audioSource.PlayOneShot(clip);
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    { 
        yield return new WaitForSeconds(f);

        //If the button is still in focus
        if (inFocus)
        {
            ReadNumber();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //If a button currently has the pointer on it
        if (inFocus)
        {

            if (playing)
            {
                audioSource.Stop();
            }

            inFocus = false;
        }
    }
}
