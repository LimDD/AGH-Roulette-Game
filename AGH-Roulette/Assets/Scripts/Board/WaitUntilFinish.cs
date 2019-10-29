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
        //Once the sound has stopped
        if (!source.isPlaying)
        {
            if (betReader != null)
            {
                //Now betReader can be unmuted
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
