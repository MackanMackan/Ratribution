using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIFollowPlayer : IAIState
{

    GameObject player;
    NavMeshAgent agent;
    AIStateMachine stateMachine;
    MonoBehaviour mono;
    private void StopAndLookAtPlayer()
    {
        agent.destination = agent.transform.position;
        agent.transform.LookAt(player.transform);
        stateMachine.ChangeState(new AIAttackPlayer());
    }

    void MoveTowardsPlayer()
    {
        agent.destination = player.transform.position;
    }

    public void InitializeState(NavMeshAgent agent, GameObject player, AIStateMachine stateMachine, MonoBehaviour mono)
    {
        this.agent = agent;
        this.player = player;
        this.stateMachine = stateMachine;
        this.mono = mono;
    }

    public void ExecuteState(bool atAttackDistance)
    {
        if (!atAttackDistance)
        {
            MoveTowardsPlayer();
        }
        else
        {
            StopAndLookAtPlayer();
        }
    }

    public void UnInitilizeState()
    {
    }
}
