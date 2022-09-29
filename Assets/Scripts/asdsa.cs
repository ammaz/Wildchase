using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdsa : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        /*if (other.tag == "Player")
        {
            Minions.playerscore--;
            Debug.Log(Minions.playerscore);
        }*/
    }
}
