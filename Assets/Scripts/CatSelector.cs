using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSelector : MonoBehaviour
{
    public static int currentCatIndex1;
    public GameObject[] cats;

    // Start is called before the first frame update
    void Start()
    {
        currentCatIndex1 = PlayerPrefs.GetInt("SelectedCat", 0);

        foreach (GameObject cat in cats)
            cat.SetActive(false);

        cats[currentCatIndex1].SetActive(true);
    }
}
