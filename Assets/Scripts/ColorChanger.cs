using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    //MeshRenderer colormeshchanger;
    SkinnedMeshRenderer colormeshchanger;
    [SerializeField] [Range(0f, 5f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;
    float t = 0f;
    int len;

    void Start()
    {
        colormeshchanger = GetComponent <SkinnedMeshRenderer>();
        len = myColors.Length;
    }

    void Update()
    {
        colormeshchanger.material.color = Color.Lerp(colormeshchanger.material.color, myColors[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
