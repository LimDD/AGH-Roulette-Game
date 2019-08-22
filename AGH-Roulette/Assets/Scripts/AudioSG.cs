using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSG : MonoBehaviour
{
    /*public AudioClip startGameButton;
    public AudioClip tutorialButton;
    public AudioClip gameControlsButton;
    public AudioClip betsOfRouletteButton;
    public AudioClip highScoresButton;
    public AudioClip achievementsButton;
    */
    public AudioSource source;
    public AudioClip hoverSound;

    // Start is called before the first frame update
   /* void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        source.clip = startGameButton;
        source.Play();
    }

    public void Tutorial()
    {
        source.clip = tutorialButton;
        source.Play();
    }

    public void GameControls()
    {
        source.clip = gameControlsButton;
        source.Play();
    }

    public void betsOfRoulette()
    {
        source.clip = betsOfRouletteButton;
        source.Play();
    }

    public void HighScores()
    {
        source.clip = highScoresButton;
        source.Play();
    }

    public void Achievements()
    {
        source.clip = achievementsButton;
        source.Play();
        //HoverSound(source.clip);
        //HoverSound(achievementsButton);
    }
    */

    public void HoverSound()
    {
        source.PlayOneShot(hoverSound);
    }

}