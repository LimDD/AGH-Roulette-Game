using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SplashScreenDelay : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        if (!SplashScreen.isFinished)
        {
            StartCoroutine(Wait(0.1f));
        }

        else
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    public IEnumerator Wait(float f)
    {
        yield return new WaitForSeconds(f);
        Start();
    }
}
