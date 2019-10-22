using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //plays note sound if the source is active
    public void Play()
    {
        if (source.isActiveAndEnabled)
        {
            source.Play();
        }
    }
}
