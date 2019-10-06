using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    SceneSwitcher sS;
    public static DontDestroy Instance;
    public GameObject gObject;

    void Awake()
    {
        sS = FindObjectOfType<SceneSwitcher>();
        DontDestroyOnLoad(this);
    }

    public void Destroy()
    {
        Destroy(gObject);
    }
}
