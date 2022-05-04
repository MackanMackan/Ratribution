using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAttackPlayer : IAIState
{
    GameObject player;
    NavMeshAgent agent;
    AIStateMachine stateMachine;
    OwlianAnimationHandler owlAnimation;
    MonoBehaviour mono;
    bool isAttacking;

    float attackingTime = 4;
    public void ExecuteState(bool atAttackDistance)
    {
        if (atAttackDistance)
        {
            AttackPlayer();
            agent.transform.LookAt(player.transform);
        }
        else
        {
            stateMachine.ChangeState(new AIFollowPlayer());
        }
    }

    public void InitializeState(NavMeshAgent agent, GameObject player, AIStateMachine stateMachine, MonoBehaviour mono)
    {
        this.agent = agent;
        this.player = player;
        this.stateMachine = stateMachine;
        owlAnimation = stateMachine.GetComponent<OwlianAnimationHandler>();
        this.mono = mono;
    }

    public void UnInitilizeState()
    {
        
    }
    void AttackPlayer()
    {
        if (!isAttacking)
        {
            mono.StartCoroutine(AttackingTimer());
        }
    }
    IEnumerator  AttackingTimer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackingTime);
        owlAnimation.DoAttackAnimation();
        isAttacking = false;
    }
}
