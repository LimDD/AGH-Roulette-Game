using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip zeroBal;
    public AudioSource source;

    public void NoCoins()
    {

        source = GetComponent<AudioSource>();
        source.Play();
        Debug.Log("yep ur here");
    }
}
