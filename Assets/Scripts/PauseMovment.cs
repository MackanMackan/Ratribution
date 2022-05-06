using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PauseMovment : MonoBehaviour
{
    GameObject player;
    public OwlSpawn owlSpawn;
    public CinemachineSwitch cinemachineSwitch;
    CharacterMovement characterMovement;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterMovement = player.GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (cinemachineSwitch.isGate)
        {
            StopMovment(false);
        }

       else
        {
            StopMovment(true);
        }
    }

    private void StopMovment(bool value)
    {
        characterMovement.enabled = value;

        foreach (GameObject owls in owlSpawn.numberOfOwls)
        {
            owls.GetComponent<AIStateMachine>().enabled = value;
            owls.GetComponent<OwlianAnimationHandler>().enabled = value;
            owls.GetComponent<NavMeshAgent>().enabled = value;
        }

        owlSpawn.enabled = value;
    }
}
