using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineVirtualCamera vCam;

    private void Start()
    {      
        vCam = GetComponent<CinemachineVirtualCamera>();
        refPlayer = GameObject.FindGameObjectWithTag("Player");

        vCam.Follow = refPlayer.transform;
        vCam.LookAt = refPlayer.transform;
    }
}

