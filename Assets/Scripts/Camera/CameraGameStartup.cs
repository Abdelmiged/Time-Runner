using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGameStartup : MonoBehaviour
{
    Transform playerFollowPoint;

    private void Update()
    {
        while(true)
        {
            playerFollowPoint = GameObject.FindGameObjectWithTag("Player").transform.Find("FollowPoint");
            Cinemachine.CinemachineVirtualCamera virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
            virtualCamera.Follow = playerFollowPoint;
            virtualCamera.LookAt = playerFollowPoint;
            if (playerFollowPoint != null)
                break;
        }

        gameObject.GetComponent<CameraGameStartup>().enabled = false;
    }
}
