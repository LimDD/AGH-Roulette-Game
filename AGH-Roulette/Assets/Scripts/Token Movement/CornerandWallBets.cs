using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerandWallBets : MonoBehaviour
{
    //public GameObject PlayerToken;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerToken = GameObject.Find("Player Token");
    }

    public void MoveUp()
    {
        gameObject.transform.Translate(0f, 59.0f, 0f);
    }

    public void MoveTopRight()
    {
        gameObject.transform.Translate(98.0f, 59.0f, 0f);
    }

    public void MoveRight()
    {
        gameObject.transform.Translate(98.0f, 0f, 0f);
    }

    public void MoveBottomRight()
    {
        gameObject.transform.Translate(98.0f, -59.0f, 0f);
    }

    public void MoveDown()
    {
        gameObject.transform.Translate(0f, -59.0f, 0f);
    }

    public void MoveBottomLeft()
    {
        gameObject.transform.Translate(-98.0f, -59.0f, 0f);
    }

    public void MoveLeft()
    {
        gameObject.transform.Translate(-98.0f, 0f, 0f);
    }

    public void MoveTopLeft()
    {
        gameObject.transform.Translate(-98.0f, 59.0f, 0f);
    }
}
