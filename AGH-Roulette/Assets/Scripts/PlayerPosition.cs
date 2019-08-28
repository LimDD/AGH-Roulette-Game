using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField]
    //Holds position of the object
    private Transform playerPlace;
    //Position where the icon returns when new bet will be placed
    private Vector2 initialPosition;
    
    private Vector2 mousePosition;
    //Used to calculate the position of the object and mouse/touch position
    private float deltaX, deltaY;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }


    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp()
    {
        /*
        if(Mathf.Abs(transform.position.x - playerPlace.position.x) <= 0.5f 
            && Mathf.Abs(transform.position.y - playerPlace.position.y) <= 0.5f)
        {

        }
        */
        transform.position = new Vector2(playerPlace.position.x, playerPlace.position.y);
    }
}
