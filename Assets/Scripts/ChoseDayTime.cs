using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoseDayTime : MonoBehaviour
{
    string name;
    // Start is called before the first frame update
    void Start()
    {
        Material skybox = (ScenesGlobalVariables.skybox != null) ? ScenesGlobalVariables.skybox : Resources.Load<Material>("Skybox/NightSky1/NightSkybox_1");
        RenderSettings.skybox = skybox;
        TextMeshProUGUI coins, remainingTime, time;

        coins = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        remainingTime = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>();
        time = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();

        if(skybox.name == "DaySky")
        {
            coins.color = remainingTime.color = time.color = Color.black;
        }
        else if (skybox.name == "NightSkybox_1")
        {
            coins.color = remainingTime.color = time.color = Color.white;
        }
    }
}
