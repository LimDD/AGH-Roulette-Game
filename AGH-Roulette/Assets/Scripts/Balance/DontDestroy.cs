using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lets gameobject go between main/tutorial and roulette wheel scenes
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

    //Called after the wheel has spun so it is not duplicated
    public void Destroy()
    {
        Destroy(gObject);
    }
}
