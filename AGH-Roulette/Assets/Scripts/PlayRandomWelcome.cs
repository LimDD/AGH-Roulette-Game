using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomWelcome : MonoBehaviour {

    public AudioSource _as;
    public AudioClip[] audioClipArray;

    private void Awake()
    {
    _as = GetComponent<AudioSource>();
    }
    void Start()
    {
        _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
        _as.PlayOneShot(_as.clip);
    }

}
