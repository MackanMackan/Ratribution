using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    GameObject refPlayer;
    CinemachineFreeLook vcam;
    Transform cameraPos;
    Transform introCam;

  

    private void Start()
    {
        cameraPos = GameObject.Find("FP_Cam").GetComponent<Transform>();


        vcam = GetComponent<CinemachineFreeLook>();
        
        refPlayer = GameObject.Find("Drop").GetComponent<PlayerDrop>().GO_player;
        vcam.Follow = refPlayer.transform;
        vcam.LookAt = refPlayer.transform;
    }

}
