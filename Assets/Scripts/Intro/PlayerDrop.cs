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
    [SerializeField] GameObject introCam;

    private void Awake()
    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);
        GO_player.transform.eulerAngles = new Vector3(GO_player.transform.eulerAngles.x, introCam.transform.eulerAngles.y-180, GO_player.transform.eulerAngles.z);
       cinemachineVirtualCamera2.enabled = false;
    }
    private void Start()
    {
       //player = GameObject.FindGameObjectWithTag("Player");
       //characterMovement = player.GetComponent<CharacterMovement>();
       //characterMovement.playerMoveForce = 0;
       Time.fixedDeltaTime = 0.02F;
    }
}
