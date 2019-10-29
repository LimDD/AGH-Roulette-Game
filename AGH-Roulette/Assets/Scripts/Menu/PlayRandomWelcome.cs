using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayRandomWelcome : MonoBehaviour {

    public AudioSource _as;
    public AudioClip[] audioClipArray;

    public AudioSource buttonSource;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    void Start()
    {
        //If splash screen is still active
        if (!SplashScreen.isFinished)
        {
            StartCoroutine(Wait(0.1f));
        }

        //Plays welcome message once splash screen disappears
        else
        {
            _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            _as.PlayOneShot(_as.clip);
        }
    }

    private void Update()
    {
        //Unmutes all audio sources once welcome message has finished
        if (!_as.isPlaying && SplashScreen.isFinished)
        {
            if (buttonSource != null)
            {
                if (buttonSource.mute)
                {
                    buttonSource.mute = false;
                }
            }
        }
    }

    public IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
        Start();
    }

}
