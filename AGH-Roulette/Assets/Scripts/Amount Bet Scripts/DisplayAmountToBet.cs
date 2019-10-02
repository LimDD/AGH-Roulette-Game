using UnityEngine;

public class DisplayAmountToBet : MonoBehaviour
{
    public GameObject Panel;
    public AudioSource narration;

    public void ShowHidePanel()
    {
        if (Panel != null)
        {
            narration.Stop();
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}
