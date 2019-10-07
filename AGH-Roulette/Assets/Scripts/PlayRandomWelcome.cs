using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomWelcome : MonoBehaviour {

    public AudioSource _as;
    public AudioClip[] audioClipArray;

    public AudioSource sg;
    public AudioSource t;
    public AudioSource a;
    public AudioSource hs;
    public AudioSource ror;
    public AudioSource ps;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    void Start()
    {
        _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        _as.PlayOneShot(_as.clip);
    }

    private void Update()
    {
        if (!_as.isPlaying)
        {
            if (sg.mute)
            {
                sg.mute = false;
                t.mute = false;
                a.mute = false;
                hs.mute = false;
                ror.mute = false;
                ps.mute = false;
            }
        }
    }

}
