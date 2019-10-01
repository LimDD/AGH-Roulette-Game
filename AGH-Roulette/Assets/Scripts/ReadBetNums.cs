﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBetNums : MonoBehaviour
{
    public NumberReader numberReader;
    public int NumToRead;

    AudioSource audioSource;
    AudioClip[] clips;
    List<AudioClip> clipList;
    public int currentClip;
    public int lastClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (lastClip > 0)
        {
            IterateClipList(clipList);
        }
    }

    public void SetNumberList(List<int> num)
    {
        clipList = new List<AudioClip>();

        foreach (int i in num)
        {
            clips = numberReader.GetNumberAudio(i);
            clipList.Add(clips[0]);
        }

        lastClip = clipList.Count;
        currentClip = 0;
    }

    private void IterateClipList(List<AudioClip> clips)
    {
        while ((currentClip < lastClip) && (!audioSource.isPlaying))
        {
            Debug.Log("Playing clip" + currentClip + " of " + lastClip + " which is " + clips[currentClip].name);
            audioSource.clip = clips[currentClip];
            audioSource.Play();

            currentClip++;
        }
    }
}