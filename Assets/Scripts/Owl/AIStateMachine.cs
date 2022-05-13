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
    float baseAttackDistance = 15;
    float attackDistanceAdded = 10;
    public bool atAttackDistance = false;
    bool startChecking = false;
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
        if(animHandler && !atAttackDistance)
        {
            animHandler.DoRunAnimation(Mathf.Abs(agent.velocity.x+ agent.velocity.y+ agent.velocity.z));
        }
        else
        {
            animHandler.DoRunAnimation(0);
        }
        
    }
    private void FixedUpdate()
    {
        if (startChecking)
            CastRayToPlayer();

        if (player)
            aiState.ExecuteState(atAttackDistance);
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
        startChecking = true;
    }
    void CastRayToPlayer()
    {
        Vector3 direction = player.transform.position - agent.transform.position;
        direction += Vector3.up * 3;
        direction.Normalize();
        Debug.DrawRay(agent.transform.position + Vector3.up * 3, direction, Color.blue, 10);
        if (Physics.Raycast(agent.transform.position + Vector3.up * 3, direction, out RaycastHit hitInfo, attackDistance))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                atAttackDistance = true;
                attackDistance = baseAttackDistance + attackDistanceAdded;
            }
            else
            {
                atAttackDistance = false;
                attackDistance = baseAttackDistance;
            }
        }
        else
        {
            atAttackDistance = false;
        }
    }
}
