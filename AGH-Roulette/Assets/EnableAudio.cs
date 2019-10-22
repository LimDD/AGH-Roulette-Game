using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAudio : MonoBehaviour
{
    public AudioSource narrator;
    AudioSource[] sources;

    public GameObject panel;
    string lastPanel;
    bool isEnabled;


    // Start is called before the first frame update
    private void Start()
    {
        sources = panel.GetComponentsInChildren<AudioSource>();
        enabled = false;
    }

    void Update()
    {
        if (!isEnabled)
        {
            if (narrator.isPlaying)
            {
                //Don't play
            }

            else
            {
                foreach (AudioSource s in sources)
                {
                    s.enabled = true;
                    if (s.isPlaying)
                    {
                        s.Stop();
                    }
                }
                isEnabled = true;
            }
        }
    }
}
