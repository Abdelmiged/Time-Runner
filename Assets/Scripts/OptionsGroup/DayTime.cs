using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour
{
    ToggleGroup toggleGroup;
    string chosen = "";
    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

        if(toggle.name == "DayTime" && toggle.name != chosen)
        {
            ChooseDayTime("Skybox/DaySky/DaySky");
            chosen = toggle.name;
        }
        else if (toggle.name == "NightTime" && toggle.name != chosen)
        {
            ChooseDayTime("Skybox/NightSky1/NightSkybox_1");
            chosen = toggle.name;
        }
    }

    private void ChooseDayTime(string path)
    {
        ScenesGlobalVariables.skybox = Resources.Load<Material>(path);
    }
}
