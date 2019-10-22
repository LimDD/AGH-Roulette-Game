using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsSoundManager : MonoBehaviour
{
    public AudioSource soundManager;

    public AudioClip luckyDay;
    public AudioClip twoWinStreak;
    public AudioClip noEvenBets;
    public AudioClip zero;
    public AudioClip beginner;
    public AudioClip rouletteGeek;

    public void PlayLuckyDay()
    {
        soundManager.clip = luckyDay;
        soundManager.Play();
    }

    public void PlayTwoWinStreak()
    {
        soundManager.clip = twoWinStreak;
        soundManager.Play();
    }

    public void PlayNoEvenBets()
    {
        soundManager.clip = noEvenBets;
        soundManager.Play();
    }

    public void PlayZero()
    {
        soundManager.clip = zero;
        soundManager.Play();
    }

    public void PlayBeginner()
    {
        soundManager.clip = beginner;
        soundManager.Play();
    }

    public void PlayRouletteGeek()
    {
        soundManager.clip = rouletteGeek;
        soundManager.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
