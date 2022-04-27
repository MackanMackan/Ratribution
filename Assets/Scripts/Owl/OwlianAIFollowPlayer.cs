using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OwlianAIFollowPlayer :  IAIState
{

    [SerializeField] GameObject player;
    [SerializeField] float attackDistance;
    NavMeshAgent agent;
    MonoBehaviour mono;
    bool atAttackDistance = false;

    private void StopAndLookAtPlayer()
    {
        agent.destination = agent.transform.position;
        agent.transform.LookAt(player.transform);
    }

    void MoveTowardsPlayer()
    {
        agent.destination = player.transform.position;
    }
    IEnumerator CheckForPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = player.transform.position - agent.transform.position;
        direction.Normalize();
        if (Physics.Raycast(agent.transform.position, direction, out RaycastHit hitInfo, attackDistance))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                atAttackDistance = true;
            }
            else
            {
                atAttackDistance = false;
            }
        }
        else
        {
            atAttackDistance = false;
        }
        mono.StartCoroutine(CheckForPlayer());
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(10f);
        player = GameObject.Find("Player(Clone)");
        mono.StartCoroutine(CheckForPlayer());
    }

    public void InitializeState(NavMeshAgent agent, GameObject player)
    {
        this.agent = agent;
        this.player = player;
        mono = new MonoBehaviour();
        mono.StartCoroutine(GetPlayerRef());
    }

    public void ExecuteState()
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
