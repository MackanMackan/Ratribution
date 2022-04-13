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
    public CinemachineFreeLook cinemachineFreeLook;

    private void Awake()
    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);
       cinemachineFreeLook.enabled = false ;
    }
}
