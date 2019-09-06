using UnityEngine;

public class PlaceToken : MonoBehaviour
{
    public float coordx, coordy, coordz;
    public GameObject playerToken;
    public GameObject table;

    void Start()
    {
        coordx = transform.position.x;
        coordy = transform.position.y;
        coordz = transform.position.z;
    }

    public void MoveToken()
    {
        playerToken.SetActive(true);

        playerToken.transform.position = new Vector3(coordx, coordy, coordz);
        playerToken.SetActive(false);
    }
}
