using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleNumber : MonoBehaviour
{
    public NumberReader numberReader;

    [Header("Press A after changing the number to read")]
    public int NumToRead;

    AudioSource audioSource;
    AudioClip[] clips;
    public int currentClip;
    public int lastClip;
    //public AudioSource[] audioSourceArray;
    //int toggle = 0;
    //double duration = 2.00;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clips = numberReader.GetNumberAudio(NumToRead);
        currentClip = 0;
        lastClip = clips.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
            PlayAudio();
            
            //for (int i = 0; i < clips.Length; i++)
            //{
                //Printing out the clip needed to be played
                
                //audioSourceArray[i].clip = clips[i];
                //audioSourceArray[i].PlayScheduled(AudioSettings.dspTime + getLength(clips[i]));


                //toggle = 1 - toggle;


                //audioSource.clip = clips[i];
                //audioSource.Play();
            //}
        //}

        //double getLength(AudioClip clip)
        //{
        //    double clipLength = (double)clip.samples / clip.frequency;

        //    return clipLength;
        //}
    }

    private void PlayAudio()
    {
        while (currentClip < lastClip && audioSource.isPlaying == false)
        {
            Debug.Log("Giving " + clips[currentClip].name + " to AS");
            audioSource.clip = clips[currentClip];
            audioSource.Play();

            currentClip++;
        }
    }
}
