using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTokens : MonoBehaviour
{
    public GameObject PlayerToken;
    public GameObject table;

    public void ShowDuplicates()
    {
        GameObject duplicate = Instantiate(PlayerToken);
        duplicate.transform.SetParent(table.transform);
        duplicate.transform.position = PlayerToken.transform.position;
    }
}
