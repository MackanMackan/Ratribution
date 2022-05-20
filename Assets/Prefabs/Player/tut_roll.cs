using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_roll : StateMachineBehaviour

{
    GameObject player;
    Tut_Attack tut_Attack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tut_Attack = player.GetComponent<Tut_Attack>();

        tut_Attack.hitterRoll.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

}
