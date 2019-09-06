using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public float coordx, coordy, coordz;
    public GameObject PlayerToken;

    void Start()
    {
        coordx = transform.position.x;
        coordy = transform.position.y;
        coordz = transform.position.z;
    }

    public void MoveToken()
    {
        PlayerToken.SetActive(true);
        PlayerToken = GameObject.Find("Player Token");
        PlayerToken.transform.position = new Vector3(coordx, coordy, coordz);
        PlayerToken.SetActive(false);
    }
}
