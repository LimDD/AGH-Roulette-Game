using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public AudioClip sound;
    AudioSource source;
    public Button btn;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        source.PlayOneShot(sound);
    }

    public void SetPitch()
    {
        string num = btn.GetComponentInChildren<TMP_Text>().text;

        float number = float.Parse(num);

        source.pitch = 0.9f + (number * 0.02f);

        Play();
    }
}
