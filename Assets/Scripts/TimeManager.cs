using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    private TextMeshProUGUI timeRemaining;
    bool zero = false;
    private void Start()
    {
        timeRemaining = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        timeRemaining.text = "200";
        InvokeRepeating("TimeCounter", 0f, 1f);
    }

    private void Update()
    {
        if(Convert.ToInt32(timeRemaining.text) <= 0 && !zero)
        {
            CancelInvoke("TimeCounter");
            zero = true;
            TimeIsOut();
        }
    }

    private void TimeCounter()
    {
        timeRemaining.text = (Convert.ToInt32(timeRemaining.text) - 1).ToString();
    }

    private void TimeIsOut()
    {
        TextMeshProUGUI gameOver = GameObject.FindGameObjectWithTag("UI").transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        gameOver.enabled = true;
        GameStateManager.GameOver();
        StartCoroutine("ReturnToMainMenu");
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameStateManager.ReturnToMainMenu();
    }
}