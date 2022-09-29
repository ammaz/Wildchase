using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
   // public static bool gameOver;
    //public GameObject gameOverPanel;

    public PlayerManager obj1;

    //public static bool isGameStarted;
    //public GameObject startingText;

    //public int numberOfCoins;
    public Text coinsText;
    //public bool call = true;

    // Start is called before the first frame update
    void Start()
    {
        //gameOver = false;
        /*Time.timeScale = 1;
        isGameStarted = false;*/

        //obj1 = GetComponent<PlayerManager>();

        //Initializing Number of Coins from Save File

        string path = Application.persistentDataPath + "/Save.fun";
        if (!File.Exists(path))
        {
            obj1.SavePlayer();
        }
        obj1.LoadPlayer();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }*/

        coinsText.text = "Coins : " + PlayerManager.numberOfCoins;

        /*if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }*/
    }

    /*public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }*/

    /*public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        numberOfCoins = data.coin;
    }*/
}
