using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1Start()
    {
        StartCoroutine(Level1());
    }

    IEnumerator Level1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void Level2Start()
    {
        StartCoroutine(Level2());
    }

    IEnumerator Level2()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }

    public void Level3Start()
    {
        StartCoroutine(Level3());
    }

    IEnumerator Level3()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(3);
    }

    public void Level4Start()
    {
        StartCoroutine(Level4());
    }

    IEnumerator Level4()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(4);
    }

    public void Level5Start()
    {
        StartCoroutine(Level5());
    }

    IEnumerator Level5()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(5);
    }
}
