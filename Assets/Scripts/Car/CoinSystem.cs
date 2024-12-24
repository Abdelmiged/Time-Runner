using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    private static int coins = 0;
    private TextMeshProUGUI coinText;
    [SerializeField]
    private GameObject coinsContainer;
    TextMeshProUGUI win;
    private void Start()
    {
        coinsContainer = GameObject.FindGameObjectWithTag("CoinsContainer");
        win = GameObject.FindGameObjectWithTag("UI").transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        coins = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "CoinBrass" && other.gameObject.tag != "CoinSilver" && other.gameObject.tag != "CoinGold" && other.gameObject.tag != "CoinDarkGold")
            return;

        GameObject coinAudioObject = LoadPrefabOnObject("AudioObjectsPrefabs/CoinAudioObject");
        coinAudioObject = Instantiate(coinAudioObject);
        coinAudioObject.GetComponent<AudioSource>().clip = other.gameObject.GetComponent<AudioSource>().clip;
        coinAudioObject.GetComponent<AudioSource>().Play();

        if (other.gameObject.tag == "CoinBrass")
        {
            coins++;
            IncrementCoins();
            Destroy(other.gameObject);
            Destroy(coinAudioObject, coinAudioObject.GetComponent<ParticleSystem>().main.duration);
        }
        else if (other.gameObject.tag == "CoinSilver")
        {
            coins += 2;
            IncrementCoins();
            Destroy(other.gameObject);
            Destroy(coinAudioObject, coinAudioObject.GetComponent<ParticleSystem>().main.duration);
        }
        else if (other.gameObject.tag == "CoinGold")
        {
            coins += 3;
            IncrementCoins();
            Destroy(other.gameObject);
            Destroy(coinAudioObject, coinAudioObject.GetComponent<ParticleSystem>().main.duration);
        }
        else if (other.gameObject.tag == "CoinDarkGold")
        {
            coins += 4;
            IncrementCoins();
            Destroy(other.gameObject);
            Destroy(coinAudioObject, coinAudioObject.GetComponent<ParticleSystem>().main.duration);
        }

        
        Invoke("CheckWin", Time.deltaTime);
    }
    private GameObject LoadPrefabOnObject(string path)
    {
        GameObject audioObject = Resources.Load<GameObject>(path);
        audioObject.transform.position = gameObject.transform.position;
        return audioObject;
    }

    private void IncrementCoins()
    {
        coinText = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        coinText.text = "";
        coinText.text += "Coins: " + coins.ToString();
    }

    private void CheckWin()
    {
        if (coinsContainer.transform.childCount != 0)
            return;

        win.enabled = true;
        GameStateManager.Win();
        StartCoroutine("ReturnToMainMenu");
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameStateManager.ReturnToMainMenu();
    }
}