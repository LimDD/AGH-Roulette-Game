using System.Collections;
using UnityEngine;

public class ReadNumbers : MonoBehaviour
{
    public NumberReader numberReader;
    int numToRead;

    AudioSource audioSource;

    private void Awake()
    {
        numToRead = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ReadNumber(string name)
    {
        int.Parse(name);

        numToRead = int.Parse(name);

        AudioClip[] clips = numberReader.GetNumberAudio(numToRead);

        for(int i= 0; i < clips.Length; i++)
        {
            StartCoroutine(ClipDelay(clips[i], i));
            Debug.Log(clips[i].name);
        }
    }

    //If the there is more than 1 clip add a delay between them
    public IEnumerator ClipDelay(AudioClip clip, int count)
    {
        if (count > 0)
        {
            yield return new WaitForSeconds(0.36f * count);
        }

        audioSource.pitch = 1f;
        audioSource.PlayOneShot(clip);
    }
}
