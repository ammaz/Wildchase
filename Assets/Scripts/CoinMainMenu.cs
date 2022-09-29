using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CoinMainMenu : MonoBehaviour
{
    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/Save.fun";
        if (!File.Exists(path))
        {
            //SaveSystem.SavePlayer(this);
        }
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerManager.numberOfCoins = data.coin;
        coinsText.text = "Coins : " + PlayerManager.numberOfCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
