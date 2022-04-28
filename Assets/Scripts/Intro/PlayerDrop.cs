using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDrop : MonoBehaviour
{
    public GameObject player;
    public GameObject dropPlace;
    [HideInInspector]
    public GameObject GO_player;
    public CinemachineVirtualCamera cinemachineVirtualCamera1;
    public CinemachineVirtualCamera cinemachineVirtualCamera2;

    private void Awake()
    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);
       cinemachineVirtualCamera1.enabled = false ;
       cinemachineVirtualCamera2.enabled = false;

    }
}
