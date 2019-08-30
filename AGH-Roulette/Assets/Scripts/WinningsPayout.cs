using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningsPayout : MonoBehaviour
{
    //In this class I would have an instance of another class storing the balance variable
    public void GetWinnings(string bet, int amount)
    {
        if (bet == "trio" || bet == "street")
        {
            //balance += amount * 12;
        }

        if (bet == "odd" || bet == "even" || bet == "red" || bet == "black")
        {
            //balance += amount * 2;
        }

        if (bet == "1st Third" || bet == "2nd Third" || bet == "3rd Third")
        {
            //balance += amount * 3;
        }

        if (bet == "single")
        {
            //balance += amount * 36;
        }

        if (bet == "split")
        {
            //balance += amount * 18;
        }

        if (bet == "corner")
        {
            //balance += amount * 9;
        }
    }
}
