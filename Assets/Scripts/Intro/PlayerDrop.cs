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
    public CinemachineVirtualCamera cinemachineVirtualCamera2;
    CharacterMovement characterMovement;

    private void Awake()
    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);
       cinemachineVirtualCamera2.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        characterMovement = player.GetComponent<CharacterMovement>();
        characterMovement.playerMoveForce = 0;
        Time.fixedDeltaTime = 0.02F;
    }
}
