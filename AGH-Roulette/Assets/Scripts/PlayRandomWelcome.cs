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

        if (!SplashScreen.isFinished)
        {
            StartCoroutine(Wait(0.1f));
        }

        else
        {
            _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            _as.PlayOneShot(_as.clip);
        }
    }

    private void Update()
    {
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
