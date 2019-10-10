using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUntilFinish : MonoBehaviour
{
    public AudioSource source;
    public AudioSource betReader;
    SceneSwitcher sS;

    void Update()
    {
        if (!source.isPlaying)
        {
            if (betReader != null)
            {
                if (betReader.mute)
                {
                    betReader.Stop();
                    betReader.mute = false;
                }
            }

            else
            {
                sS = FindObjectOfType<SceneSwitcher>();
                sS.MenuScene();
            }

        }
    }
}
