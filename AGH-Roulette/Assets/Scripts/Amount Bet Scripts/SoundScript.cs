using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        string btnName;
        float num = 0;
        btnName = btn.name;

        if (btnName.Contains("_Cell"))
        {
            btnName = btn.GetComponentInChildren<TMP_Text>().text;

            btnName = Regex.Replace(btnName, "[^.0-9]", "");
            float.TryParse(btnName, out num);

            if (num % 3 != 1 && num != 0)
            {
                if (num % 3 == 2)
                {
                    source.panStereo = 0.3f;
                }

                else
                {
                    source.panStereo = 0.6f;
                }
            }
        }

        else
        {
            switch (btnName)
            {
                case "1st_Third":
                    num = 6.5f;
                    source.panStereo = -0.3f;
                    break;

                case "2nd_Third":
                    num = 18.5f;
                    source.panStereo = -0.3f;
                    break;

                case "3rd_Third":
                    num = 30.5f;
                    source.panStereo = -0.3f;
                    break;

                case "1_To_18":
                    num = 3.5f;
                    source.panStereo = -0.6f;
                    break;

                case "Evens":
                    num = 9.5f;
                    source.panStereo = -0.6f;
                    break;

                case "Odds":
                    num = 27.5f;
                    source.panStereo = -0.6f;
                    break;

                case "Reds":
                    num = 15.5f;
                    source.panStereo = -0.6f;
                    break;

                case "Blacks":
                    num = 21.5f;
                    source.panStereo = -0.6f;
                    break;

                case "1st_Column":
                    num = 37;
                    break;

                case "2nd_Column":
                    num = 38;
                    source.panStereo = 0.3f;
                    break;

                case "3rd_Column":
                    num = 39;
                    source.panStereo = 0.6f;
                    break;

                case "19_To_36":
                    num = 33.5f;
                    source.panStereo = -0.6f;
                    break;

            }
        }
        source.pitch = 0.9f + (num * 0.02f);

        Play();
    }
}
