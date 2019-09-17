using UnityEngine;

//Sets the position of the duplicated coin to the coins position and size
public class DuplicateCoin : MonoBehaviour
{
    public GameObject playerToken;
    public GameObject table;

    public void ShowDuplicates()
    {
        GameObject duplicate = Instantiate(playerToken);
        Vector2 vec = new Vector2(1f, 1f);

        duplicate.transform.SetParent(table.transform);
        duplicate.transform.position = playerToken.transform.position;
        duplicate.transform.localScale = vec;
    }
}
