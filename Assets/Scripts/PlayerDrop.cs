using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    public GameObject player;
    public GameObject dropPlace;
    public GameObject GO_player; 

    private void Awake()

    {
       Vector3 spawnPosition = dropPlace.transform.position;
       GO_player = Instantiate(player, spawnPosition, Quaternion.identity);                      
    }

    private void Update()
    {
        //CinemachineShake.Instance.Shake(5f,1f);
    }

}
