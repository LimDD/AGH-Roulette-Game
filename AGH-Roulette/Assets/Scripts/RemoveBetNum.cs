using System.Collections.Generic;
using UnityEngine;

public class RemoveBetNum : MonoBehaviour
{
    public GameObject panel;
    SaveBetInfo sBI;

    private void Start()
    {
        sBI = FindObjectOfType<SaveBetInfo>();
    }

    public void CheckPanel()
    {
        if (panel.activeSelf)
        {
            RemoveBet();
        }
    }

    public void RemoveBet()
    {
        List<string> bets = sBI.GetSavedNums();
        int length = sBI.winNum.Count;

        for (int i = 0; i <= length; i++)
        {
            bets.RemoveAt(bets.Count - 1);
        }
    }
}
