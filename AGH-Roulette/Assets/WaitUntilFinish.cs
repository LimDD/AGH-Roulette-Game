using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilFinish : MonoBehaviour
{
    public AudioSource source;
    public AudioSource betReader;
    void Update()
    {
        if (!source.isPlaying)
        {
            if (betReader.mute)
            {
                betReader.Stop();
                betReader.mute = false;
            }
        }
    }
}
