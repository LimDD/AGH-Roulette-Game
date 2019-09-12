using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip buttonPress;
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Click()
    {
        source.pitch = 1f;
        source.PlayOneShot(buttonPress, 0.7f);
    }
}
