using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    //Replay and back to menu buttons
    public Text menutxt;
    public Text newBet;

    public void ShowButton()
    {
        //The interactable colour is opaque so the buttons cannot be seen until they are interactable
        menutxt.GetComponentInParent<Button>().interactable = true;
        newBet.GetComponentInParent<Button>().interactable = true;
    }

}
