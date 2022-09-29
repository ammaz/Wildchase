using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ShopManager : MonoBehaviour
{
    public int currentCatIndex;
    public GameObject[] catModels;

    public carBlueprint[] cats;
    public Button buyButton;
    private int coins;


    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/Save.fun";
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadPlayer();
            coins = data.coin;
        }

        foreach (carBlueprint cat in cats)
        {
            if (cat.price == 0)
                cat.isUnlocked = true;
            else
                cat.isUnlocked = PlayerPrefs.GetInt(cat.name, 0) == 0 ? false : true;
        }

        currentCatIndex = PlayerPrefs.GetInt("SelectedCat", 0);

        foreach (GameObject cat in catModels)
            cat.SetActive(false);

        catModels[currentCatIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        catModels[currentCatIndex].SetActive(false);
        currentCatIndex++;

        if (currentCatIndex == catModels.Length)
        {
            currentCatIndex = 0;
        }

        catModels[currentCatIndex].SetActive(true);
        carBlueprint c = cats[currentCatIndex];
        if (!c.isUnlocked)
        {
            return;
        }
        PlayerPrefs.SetInt("SelectedCat", currentCatIndex);

    }

    public void ChangePrevious()
    {
        catModels[currentCatIndex].SetActive(false);
        currentCatIndex--;

        if (currentCatIndex == -1)
        {
            currentCatIndex = catModels.Length -1;
        }

        catModels[currentCatIndex].SetActive(true);

        carBlueprint c = cats[currentCatIndex];
        if (!c.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedCat", currentCatIndex);
    }

    public void UnlockCar()
    {
        carBlueprint c = cats[currentCatIndex];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCat", currentCatIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - c.price);
        PlayerManager.numberOfCoins = PlayerManager.numberOfCoins - c.price;
    }

    public void UpdateUI()
    {
        carBlueprint c = cats[currentCatIndex];
        if (c.isUnlocked)
            buyButton.gameObject.SetActive(false);
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy-" + c.price;
            if(coins>=c.price)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }
}
