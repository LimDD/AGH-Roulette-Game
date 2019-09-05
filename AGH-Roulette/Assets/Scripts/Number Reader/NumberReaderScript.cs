﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberReaderScript : MonoBehaviour
{
    public NumberReader numberReader;

    [Header("Press A after changing the number to read")]
    public int NumToRead;

    AudioSource audioSource;
    AudioClip[] clips;
    public int currentClip;
    public int lastClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clips = numberReader.GetNumberAudio(NumToRead);
        lastClip = clips.Length;
        currentClip = lastClip;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Iterating through clips
        IterateClips();

        //If spacebar is pressed play the last set number
        //Set for debugging purposes
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ReadNumber();
        }
    }

    //IterateClips
    //Iterates through clips in queue and plays them one by one
    private void IterateClips()
    {
        while ((currentClip < lastClip) && (!audioSource.isPlaying))
        {
            Debug.Log("Playing clip" + currentClip + " of " + lastClip + " which is " + clips[currentClip].name);
            audioSource.clip = clips[currentClip];
            audioSource.Play();

            currentClip++;
        }
    }
    
    //SetNumber
    //Takes in integer parameter
    //Sets integer parameter i as NumToRead
    public void SetNumber(int i)
    {
        NumToRead = i;
    }

    //GetNumber
    //Returns currently set number in NumToRead
    public int GetNumber()
    {
        return NumToRead;
    }

    //ReadNumber
    //Sets currentClip to 0, initiating reading of the currently set number
    public void ReadNumber()
    {
        currentClip = 0;
    }
}
