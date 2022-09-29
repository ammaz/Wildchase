using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;
    public bool call=true;

    public GameObject winOverlayPanel, GameUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;

        //Initializing Number of Coins from Save File

        string path = Application.persistentDataPath + "/Save.fun";
        if (!File.Exists(path))
        {
            SavePlayer();
        }               
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            GameUI.SetActive(false);
        }

        if (BossHealth.currentHP1 <= 0 && PlayerHealth.currentHP >= 0)
        {
            winOverlayPanel.SetActive(true);
            GameUI.SetActive(false);
        }

        coinsText.text = "" + numberOfCoins;

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        numberOfCoins = data.coin;
    }
}
