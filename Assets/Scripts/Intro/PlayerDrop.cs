using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    public GameObject player;
    public GameObject dropPlace;
    [HideInInspector]
    public GameObject GO_player;
    public SwitchCamera switchCamera;

    private void Awake()
    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);
       switchCamera.IntroCamera();
    }

}
