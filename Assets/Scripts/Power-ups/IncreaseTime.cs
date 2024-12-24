using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IncreaseTime : MonoBehaviour
{
    private TextMeshProUGUI time;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.FindGameObjectWithTag("UI").transform.Find("RemainingTime").transform.Find("Time").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject audioObject = LoadPrefabOnObject("AudioObjectsPrefabs/TimePowerUpAudioObject");
            audioObject = Instantiate(audioObject);
            IncreaseTimePowerUp(time);
            audioObject.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(audioObject, audioObject.GetComponent<ParticleSystem>().main.duration);
        }
    }

    private GameObject LoadPrefabOnObject(string path)
    {
        GameObject audioObject = Resources.Load<GameObject>(path);
        audioObject.transform.position = gameObject.transform.position;
        return audioObject;
    }

    private void IncreaseTimePowerUp(TextMeshProUGUI time)
    {
        time.text = (Convert.ToInt32(time.text) + 10).ToString();
    }
}
