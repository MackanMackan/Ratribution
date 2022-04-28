using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour
{
    IAIState aiState;
    NavMeshAgent agent;
    MonoBehaviour mono;
    [SerializeField] GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aiState = new AIFollowPlayer();
        StartCoroutine(nameof(GetPlayerRef));
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
            aiState.ExecuteState();
    }
    public void ChangeState(IAIState newState)
    {
        aiState.UnInitilizeState();
        aiState = newState;
        aiState.InitializeState(agent, player, this);
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(2f);
        player = GameObject.FindGameObjectWithTag("Player");
        aiState.InitializeState(agent, player, this);
    }
}
