using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardButtonTimer : MonoBehaviour
{
    NumberReaderScript nRS;
    AudioSource audioSource;
    public AudioSource nums;
    public AudioClip[] outside;
    SelectButton sB;
    BoardGestureInput bGI;
    public Button btn;
    string num;
    public bool inside;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nRS = FindObjectOfType<NumberReaderScript>();
        sB = FindObjectOfType<SelectButton>();
        bGI = FindObjectOfType<BoardGestureInput>();
    }

    public void CallTimer()
    {
        if (btn.name.Contains("_Cell"))
        {
            inside = true;
        }

        else
        {
            inside = false;
        }

        StartCoroutine(StartCountdown(0.5f));
    }

    //Starts a countdown to check if the button is still in focus to determine whether the sound is played or not
    public IEnumerator StartCountdown(float f)
    {
        yield return new WaitForSeconds(f);

        btn.Select();
        CountdownFinished();

    }

    public void CountdownFinished()
    {
        if (audioSource.isPlaying || nums.isPlaying)
        {
            Debug.Log(audioSource.isPlaying);
            StartCoroutine(StartCountdown(0.1f));
        }

        else 
        {
            btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

            audioSource.pitch = 1f;
            audioSource.panStereo = 0f;

            string temp = btn.name;

            if (inside && audioSource.isActiveAndEnabled)
            {
                num = btn.GetComponentInChildren<TMP_Text>().text;
                int i = int.Parse(num);
                nRS.SetNumber(i);

                nRS.ReadNumber();
            }

            else if (audioSource.isActiveAndEnabled)
            {
                int count = 0;

                switch (temp)
                {
                    case "1st_Column":
                        count = 7;
                        break;

                    case "2nd_Column":
                        count = 8;
                        break;

                    case "3rd_Column":
                        count = 9;
                        break;

                    case "1st_Third":
                        count = 0;
                        break;

                    case "2nd_Third":
                        count = 1;
                        break;

                    case "3rd_Third":
                        count = 2;
                        break;

                    case "Evens":
                        count = 3;
                        break;

                    case "Odds":
                        count = 4;
                        break;

                    case "Blacks":
                        count = 5;
                        break;

                    case "Reds":
                        count = 6;
                        break;

                    case "1_To_18":
                        count = 10;
                        break;

                    case "19_To_36":
                        count = 11;
                        break;

                    default:
                        Debug.Log("naming error");
                        break;
                }


                audioSource.PlayOneShot(outside[count]);
            }
            sB.SaveButton(btn);
        }
        
    }  
}
