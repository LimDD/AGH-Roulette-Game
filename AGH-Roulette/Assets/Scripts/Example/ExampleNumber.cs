using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleNumber : MonoBehaviour
{
    public NumberReader numberReader;

    [Header("Press A after changing the number to read")]
    public int NumToRead = 0;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioClip[] clips = numberReader.GetNumberAudio(NumToRead);
            for(int i= 0; i < clips.Length; i++)
            {
                audioSource.PlayOneShot(clips[i]);
            }
        }
    }
}
