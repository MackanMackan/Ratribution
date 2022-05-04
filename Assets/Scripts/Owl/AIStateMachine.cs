using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour
{
    IAIState aiState;
    NavMeshAgent agent;
    [SerializeField] GameObject player;
    OwlianAnimationHandler animHandler;
    float attackDistance = 15;
    public bool atAttackDistance = false;
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
            aiState.ExecuteState(atAttackDistance);

        if(animHandler)
            animHandler.DoRunAnimation(Mathf.Abs(agent.velocity.x+ agent.velocity.y+ agent.velocity.z));
        
    }
    public void ChangeState(IAIState newState)
    {
        aiState.UnInitilizeState();
        aiState = newState;
        aiState.InitializeState(agent, player, this, this);
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(2f);
        player = GameObject.FindGameObjectWithTag("Player");
        aiState.InitializeState(agent, player,this,this);
        StartCoroutine(CheckForPlayer());
    }
    IEnumerator CheckForPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = player.transform.position - agent.transform.position + Vector3.up * 3;
        direction.Normalize();
        if (Physics.Raycast(agent.transform.position + direction + Vector3.up * 3, direction, out RaycastHit hitInfo, attackDistance))
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
