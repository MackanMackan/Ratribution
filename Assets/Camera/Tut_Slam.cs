using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut_Slam : StateMachineBehaviour
{
    GameObject player;
    Tut_Attack tut_Attack;
    Movment_tut movment_Tut;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tut_Attack = player.GetComponent<Tut_Attack>();
        movment_Tut = player.GetComponent<Movment_tut>();
        movment_Tut.playerMoveForce = 0;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tut_Attack.hitterSlam.SetActive(false);
        if (movment_Tut.animator.GetBool("isPunching"))
        {
            movment_Tut.playerMoveForce = movment_Tut.punchingMoveForce;
        }
        else
        {
            movment_Tut.playerMoveForce = movment_Tut.runningMoveForce;
        }
    }
}
