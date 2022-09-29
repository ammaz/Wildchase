using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Mission obj;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(obj.BossEnd());         
    }
    
}
