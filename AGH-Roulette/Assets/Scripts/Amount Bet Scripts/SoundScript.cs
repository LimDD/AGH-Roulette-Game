using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip sound;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Click()
    {
        source.pitch = 1f;
        source.PlayOneShot(sound);
    }
}
