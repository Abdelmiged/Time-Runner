using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    Light[] lights;
    private int indx = 0;
    // Start is called before the first frame update
    void Start()
    {
        lights = new Light[3];
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            lights[i] = gameObject.transform.GetChild(i).GetComponent<Light>();
            lights[i].enabled = false;
        }
        InvokeRepeating("Alternate", 0, 2f);
    }

    private void Alternate()
    {
        lights[(indx - 1 == -1) ? lights.Length - 1 : indx - 1].enabled = false;
        lights[indx].enabled = true;
        indx = (indx + 1) % lights.Length;
    }
}
