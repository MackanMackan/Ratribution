using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlianAIFollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float attackDistance;
    NavMeshAgent agent;
    bool atAttackDistance = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character");
        StartCoroutine(CheckForPlayer());
    }

    // Update is called once per frame
    void Update()
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

    private void StopAndLookAtPlayer()
    {
        agent.destination = transform.position;
        transform.LookAt(player.transform);
    }

    void MoveTowardsPlayer()
    {
        agent.destination = player.transform.position;
    }
    IEnumerator CheckForPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        if (Physics.Raycast(transform.position, direction, out RaycastHit hitInfo, attackDistance))
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
        StartCoroutine(CheckForPlayer());
    }
}
