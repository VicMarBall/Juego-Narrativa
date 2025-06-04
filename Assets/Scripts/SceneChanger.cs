using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ToIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Final Delivery");
    }

    public void ToFirstBadEnding()
    {
        SceneManager.LoadScene("FirstBadEnding");
    }

    public void ToSongBadEnding()
    {
        SceneManager.LoadScene("SongBadEnding");
    }

    public void ToSongGoodEnding()
    {
        SceneManager.LoadScene("SongGoodEnding");
    }

    public void ToSongSecretEnding()
    {
        SceneManager.LoadScene("SongSecretEnding");
    }

    public void ToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
