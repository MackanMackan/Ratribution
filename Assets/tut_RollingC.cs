using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_RollingC : MonoBehaviour
{
    [SerializeField] LayerMask destructableLayer;
    GameObject player;
    Movment_tut movment_Tut;

    [SerializeField] bool startTimer;
    [SerializeField] float timer = 2f;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movment_Tut = player.GetComponent<Movment_tut>();
    }
    private void OnDisable()
    {
        movment_Tut.playerMoveForce = movment_Tut.runningMoveForce;
    }
    private void FixedUpdate()
    {
        if (startTimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                movment_Tut.playerMoveForce = movment_Tut.runningMoveForce;
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
            movment_Tut.playerMoveForce = 5f;
            startTimer = true;
            Debug.Log("Hallå jag rulla in i dig akta flöthuvud");
        }
    }
}
