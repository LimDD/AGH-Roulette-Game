using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAmountToBet : MonoBehaviour
{
    public GameObject Panel;

    public void showHidePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }

    }
}
