using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public float coordx, coordy, coordz;
    public GameObject PlayerToken;
    public GameObject TokenCopy;


    void Start()
    {
        coordx = this.transform.position.x;
        coordy = this.transform.position.y;
        coordz = this.transform.position.z;

        PlayerToken = GameObject.Find("Player Token");

        //PlayerToken.transform.Translate(coordx, coordy, coordz);

        //PlayerToken.transform.position = new Vector3(coordx, coordy, coordz);

        //PlayerToken.SetActive(true);

        //TokenCopy = Instantiate(PlayerToken);

        //TokenCopy.transform.position = new Vector3(coordx, coordy, coordz);

        //TokenCopy.SetActive(true);
     }

    void Update()
    {
        
    }

    public void MoveToken()
    {
        PlayerToken.transform.position = new Vector3(coordx, coordy, coordz);

    }
}
