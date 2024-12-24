using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameStateManager
{
    public static void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void GameOver()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CarController>().enabled = false;
        player.GetComponent<Rigidbody>().drag = 3f;
    }

    public static void Win()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CarController>().enabled = false;
        player.GetComponent<Rigidbody>().drag = 3f;
    }
}