using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private GameObject player;
    private AudioSource[] playerAudioSources;
    private WheelCollider playerWheelCollider;
    bool carIdle = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAudioSources = player.GetComponents<AudioSource>();
        playerWheelCollider = player.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<WheelCollider>();
        Invoke("CarStart", playerAudioSources[0].clip.length);
    }

    private void FixedUpdate()
    {   
        if (Input.GetAxis("Vertical") != 0 && carIdle)
        {
            StartCoroutine("CarMoving");
            carIdle = false;
        }
        else if (Input.GetAxis("Vertical") == 0 && !carIdle)
        {
            StartCoroutine("CarIdle");
            carIdle = true;
        }
    }
    private void CarStart()
    {
        playerAudioSources[1].Play();
    }
    IEnumerator CarIdle()
    {
        float timeToFade = 0.2f;
        float timeElapsed = 0f;

        playerAudioSources[1].Play();

        while (timeElapsed < timeToFade)
        {
            playerAudioSources[1].volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            playerAudioSources[2].volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator CarMoving()
    {
        float timeToFade = 0.2f;
        float timeElapsed = 0f;

        playerAudioSources[2].Play();

        while (timeElapsed < timeToFade)
        {
            playerAudioSources[2].volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            playerAudioSources[1].volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}