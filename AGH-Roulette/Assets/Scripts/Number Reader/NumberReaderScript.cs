using System.Collections;
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
        IterateClips();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ReadNumber();
        }
    }

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

    public void ReadNumber()
    {
        currentClip = 0;
    }

}
