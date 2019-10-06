using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    SceneSwitcher sS;
    // Start is called before the first frame update
    void Awake()
    {
        sS = FindObjectOfType<SceneSwitcher>();

        if (sS.menu)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

}
