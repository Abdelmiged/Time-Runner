using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MainMenu
{
    public static void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
