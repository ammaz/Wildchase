using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
}
