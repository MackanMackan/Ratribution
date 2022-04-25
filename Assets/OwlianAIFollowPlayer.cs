using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlianAIFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveTowardsPlayer()
    {
        agent.destination = player.transform.position;
    }
}
