using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomConfirmation : MonoBehaviour
{
    public AudioClip confirmationExcellent;
    public AudioClip confirmationGreat;
    public AudioClip confirmationPerfect;

    public AudioSource soundManager;

    public bool hasPlayed;

    public int audioNum;

    // Awake is called when it is awoken
    private void Awake()
    {
        PlayRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPlayed == false)
        {
            PlayRandom();
        }
    }

    //Change boolean state
    public void SetHasPlayed()
    {
        hasPlayed = !hasPlayed;
    }

    //Generates an int between 0 and 2 to choose what sound is played
    public void PlayRandom()
    {
        audioNum = Random.Range(0, 2);

        if(audioNum == 0)
        {
            soundManager.clip = confirmationExcellent;
            soundManager.Play();
            SetHasPlayed();
        }
        else if(audioNum == 1)
        {
            soundManager.clip = confirmationGreat;
            soundManager.Play();
            SetHasPlayed();
        }
        else if(audioNum == 2)
        {
            soundManager.clip = confirmationPerfect;
            soundManager.Play();
            SetHasPlayed();
        }
    }
}