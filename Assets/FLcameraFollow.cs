using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FLcameraFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineFreeLook vCam;

    private void Start()
    {
        vCam = GetComponent<CinemachineFreeLook>();
        refPlayer = GameObject.FindGameObjectWithTag("Player");

        vCam.Follow = refPlayer.transform;
        vCam.LookAt = refPlayer.transform;
    }
}
