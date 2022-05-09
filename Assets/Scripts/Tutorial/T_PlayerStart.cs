using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_PlayerStart : MonoBehaviour
{
    CharacterMovement characterMovement;
    void Start()
    {
        characterMovement = FindObjectOfType<CharacterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            characterMovement.OnEnable();
        }
    }
}
