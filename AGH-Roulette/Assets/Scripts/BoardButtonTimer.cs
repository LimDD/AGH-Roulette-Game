using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardButtonTimer : MonoBehaviour
{
    NumberReaderScript nRS;
    AudioSource audioSource;
    public AudioSource narration;
    public AudioClip sound;
    public TMP_Text btnNum;
    string num;
    bool inside;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nRS = FindObjectOfType<NumberReaderScript>();
    }

    public void CallTimer()
    {
        inside = true;
        num = btnNum.text;
        StartCoroutine(StartCountdown(0.6f));
    }

    public void CallTimerOutside()
    {
        inside = false;
        StartCoroutine(StartCountdown(0.6f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        audioSource.pitch = 1f;
        audioSource.panStereo = 0f;

        if (inside)
        {
            int i = int.Parse(num);
            nRS.SetNumber(i);
            nRS.ReadNumber();
        }

        else
        {
            bool played = false;
            while (!played)
            {
                if (!narration.isPlaying)
                {
                    audioSource.Play();
                    played = true;
                }
            }
        }
    }
}
