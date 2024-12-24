using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    TextMeshProUGUI gamePausedText;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        gamePausedText = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            gamePausedText.enabled = true;
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Return) && isPaused == true)
        {
            isPaused = false;
            gamePausedText.enabled = false;
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
