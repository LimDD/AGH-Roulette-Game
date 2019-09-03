using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTokens : MonoBehaviour
{
    public GameObject PlayerToken;
    public Canvas canvas;

    public void ShowDuplicates()
    {
        GameObject duplicate = Instantiate(PlayerToken);
        duplicate.transform.SetParent(canvas.transform);
        duplicate.transform.position = PlayerToken.transform.position;
    }
}
