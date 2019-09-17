using UnityEngine;

public class DisplayAmountToBet : MonoBehaviour
{
    public GameObject Panel;
    public SoundScript Ss;

    private void Start()
    {
        Ss = FindObjectOfType<SoundScript>();
    }

    public void ShowHidePanel()
    {
        if (Panel != null)
        {
            Ss.Click();
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}
