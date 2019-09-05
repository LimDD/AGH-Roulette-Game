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
        Vector2 vec = new Vector2(1f, 1f);

        duplicate.transform.SetParent(table.transform);
        duplicate.transform.position = PlayerToken.transform.position;
        duplicate.transform.localScale = vec;
    }
}
