using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomConfirmation : MonoBehaviour
{
    public AudioClip confirmationExcellent;
    public AudioClip confirmationGreat;
    public AudioClip confirmationPerfect;

    public AudioSource soundManager;

    public bool stateActive;
    public bool hasPlayed;

    public int audioNum;

    // Awake is called when it is awoken
    private void Awake()
    {
        PlayRandom();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stateActive == true)
        {
            if(hasPlayed == false)
            {
                PlayRandom();
            }
        }
    }

    public void SetHasPlayedTrue()
    {
        hasPlayed = true;
    }

    public void SetHasPlayedFalse()
    {
        hasPlayed = false;
    }

    public void SetStateActiveTrue()
    {
        stateActive = true;
    }

    public void SetStateActiveFalse()
    {
        stateActive = false;
    }

    public void PlayRandom()
    {
        audioNum = Random.Range(0, 2);

        if(audioNum == 0)
        {
            soundManager.clip = confirmationExcellent;
            soundManager.Play();
            SetHasPlayedTrue();
        }
        else if(audioNum == 1)
        {
            soundManager.clip = confirmationGreat;
            soundManager.Play();
            SetHasPlayedTrue();
        }
        else if(audioNum == 2)
        {
            soundManager.clip = confirmationPerfect;
            soundManager.Play();
            SetHasPlayedTrue();
        }
    }
}