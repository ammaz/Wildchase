using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] target;
    private Vector3 offset;
    public static int v;
    private bool oneTime = false;

    // Start is called before the first frame update
    void Start()
    {
        v = CatSelector.currentCatIndex1;
        offset = transform.position - target[v].position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!oneTime)
        {
            Onetime();
        }
        Vector3 newPosition = new Vector3(offset.x + target[v].position.x, transform.position.y, offset.z + target[v].position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
    }

    public void Onetime()
    {
        v = CatSelector.currentCatIndex1;
        oneTime = true;
    }

}
