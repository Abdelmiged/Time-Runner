using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBorderCheck : MonoBehaviour
{
    public float loadSceneDelay = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("Respawn");
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(loadSceneDelay);
        GameStateManager.Respawn();
    }

}
