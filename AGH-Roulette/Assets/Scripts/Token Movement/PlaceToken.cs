using UnityEngine;

//Gets the position of the button clicked and moves the coin to that position
public class PlaceToken : MonoBehaviour
{
    public float coordx, coordy, coordz;
    public GameObject playerToken;

    void Start()
    {
        coordx = transform.position.x;
        coordy = transform.position.y;
        coordz = transform.position.z;
    }

    public void MoveToken()
    {
        playerToken.transform.position = new Vector3(coordx, coordy, coordz);
    }
}
