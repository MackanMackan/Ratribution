using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_leftP : StateMachineBehaviour
{
    GameObject player;
    Tut_Attack tut_Attack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tut_Attack = player.GetComponent<Tut_Attack>();

        tut_Attack.hitterL.SetActive(true);
        player.SendMessage("DiceRollForAttackVariations");
        CharacterAnimationImpact.canBeStopped = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tut_Attack.hitterL.SetActive(false);
    }
}
