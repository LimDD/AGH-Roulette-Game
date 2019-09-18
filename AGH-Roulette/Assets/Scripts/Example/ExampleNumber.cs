using System.Collections;
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
    private void ReadNumber()
    {
        string num = btnNum.text;

        int.Parse(num);

        int numToRead = int.Parse(num);

        AudioClip[] clips = numberReader.GetNumberAudio(numToRead);

        for(int i= 0; i < clips.Length; i++)
        {
            StartCoroutine(ClipDelay(clips[i], i));
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
        StartCoroutine(StartCountdown(0.5f));
    }

    //If the there is more than 1 clip add a delay between them
    public IEnumerator ClipDelay(AudioClip clip, int count)
    {
        if (count > 0)
        {
            yield return new WaitForSeconds(0.4f * count);
        }

        audioSource.PlayOneShot(clip);
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
