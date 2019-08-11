using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class stores all the sounds used when interacting with the button.
public class AudioScript : MonoBehaviour
{
    public AudioClip buttonPress;
    public AudioClip zeroBal;
    public AudioClip errorSound;
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Bet()
    {
        source.PlayOneShot(buttonPress, 0.7f);
    }

    public void NoCoins()
    {
        source.PlayOneShot(zeroBal, 0.7f);
    }

    public void ErrSound()
    {
        source.PlayOneShot(errorSound, 0.7f);
    }

}
