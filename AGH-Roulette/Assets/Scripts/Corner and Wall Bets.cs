using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerandWallBets : MonoBehaviour
{
    public GameObject PlayerToken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerToken = GameObject.Find("Player Token");


    }
}
