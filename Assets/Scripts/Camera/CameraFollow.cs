using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineVirtualCamera vCam;
    Transform cameraPos;
    Transform introCam;

    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("FP_Cam").GetComponent<Transform>();
        vCam = GetComponent<CinemachineVirtualCamera>();

        refPlayer = GameObject.FindGameObjectWithTag("Player");
        vCam.Follow = refPlayer.transform;
        vCam.LookAt = refPlayer.transform;
    }
}

