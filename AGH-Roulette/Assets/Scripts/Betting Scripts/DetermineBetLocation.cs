using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineBetLocation : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.name == "36_Cell")
        {
            Destroy(collider.gameObject);
        }
    }


}
