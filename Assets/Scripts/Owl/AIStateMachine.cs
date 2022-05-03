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
    OwlianAnimationHandler animHandler;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aiState = new AIFollowPlayer();
        animHandler = GetComponent<OwlianAnimationHandler>();
        StartCoroutine(nameof(GetPlayerRef));
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
            aiState.ExecuteState();

        if(animHandler)
            animHandler.DoRunAnimation(Mathf.Abs(agent.velocity.x+ agent.velocity.y+ agent.velocity.z));
        
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
