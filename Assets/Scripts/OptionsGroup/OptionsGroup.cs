using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Linq;

public class OptionsGroup : MonoBehaviour
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

        if(toggle.name == "Hatchback" && toggle.name != chosen)
        {
            ChooseCar("Prefabs/Cars/Hatchback_Moving");
            chosen = toggle.name;
        }
        else if(toggle.name == "Sedan" && toggle.name != chosen)
        {
            ChooseCar("Prefabs/Cars/Sedan_Moving");
            chosen = toggle.name;
        }
        else if(toggle.name == "PoliceCar" && toggle.name != chosen)
        {
            ChooseCar("Prefabs/Cars/Police_Moving");
            chosen = toggle.name;
        }
        else if(toggle.name == "Ambulance" && toggle.name != chosen)
        {
            ChooseCar("Prefabs/Cars/Ambulance_Moving");
            chosen = toggle.name;
        }
    }

    private void ChooseCar(string path)
    {
        ScenesGlobalVariables.player = Resources.Load<GameObject>(path);
    }
}
