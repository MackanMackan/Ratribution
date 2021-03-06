using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCollision : MonoBehaviour
{
    [SerializeField] LayerMask destructableLayer;
    GameObject player;
    CharacterMovement characterMovement;

    [SerializeField] bool startTimer;
    [SerializeField] float timer = 2f;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterMovement = player.GetComponent<CharacterMovement>();
    }
    private void OnDisable()
    {
        characterMovement.playerMoveForce = characterMovement.runningMoveForce;
    }
    private void FixedUpdate()
    {
        if (startTimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                characterMovement.playerMoveForce = characterMovement.runningMoveForce;
                startTimer = false;
                timer = 2f;
                Debug.Log("Nu var det klart");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            characterMovement.playerMoveForce = 5f;
            startTimer = true;
            Debug.Log("Hall? jag rulla in i dig akta fl?thuvud");
        }
    }
}
