using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    GameObject refPlayer;

    private void Start()
    {   
        var vcam = GetComponent<CinemachineFreeLook>();
        refPlayer = GameObject.Find("Drop").GetComponent<PlayerDrop>().GO_player;
        vcam.Follow = refPlayer.transform;
        vcam.LookAt = refPlayer.transform;
    }

    //TODO Freez mouse when drop
}
