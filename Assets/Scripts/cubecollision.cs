using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cubecollision : MonoBehaviour
{
    Minions asd;

    void Start()
    {
        asd = GetComponent<Minions>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mins")
        {
            if (this.gameObject.activeSelf)
            {
                if (!(Minions.playerscore <= 0))
                {
                    Minions.playerscore--;
                }
                this.gameObject.SetActive(false);
            }
                
            //asd.Mini();
        }
    }
}
