using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineFreeLook cmCam;
    Transform cameraPos;
    Transform introCam;

    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("FP_Cam").GetComponent<Transform>();
        cmCam = GetComponent<CinemachineFreeLook>();

        refPlayer = GameObject.FindGameObjectWithTag("Player");
        cmCam.Follow = refPlayer.transform;
        cmCam.LookAt = refPlayer.transform;
    }
}

