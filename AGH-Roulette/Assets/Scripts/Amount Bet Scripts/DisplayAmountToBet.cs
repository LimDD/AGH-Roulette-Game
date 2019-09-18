using UnityEngine;

public class DisplayAmountToBet : MonoBehaviour
{
    public GameObject Panel;

    public void ShowHidePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}
