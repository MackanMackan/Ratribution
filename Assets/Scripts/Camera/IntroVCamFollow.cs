using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroVCamFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineVirtualCamera introCam;


    private void Start()
    {
        CinemachineShake.Instance.cam1 = GetComponent<CinemachineVirtualCamera>();
        introCam = GetComponent<CinemachineVirtualCamera>();
        refPlayer = GameObject.FindGameObjectWithTag("Player");
        introCam.LookAt = refPlayer.transform;
    }
}
