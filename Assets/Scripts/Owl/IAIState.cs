using UnityEngine.AI;
using UnityEngine;

public interface IAIState
{
    public void InitializeState(NavMeshAgent agent,GameObject player, AIStateMachine stateMachine, MonoBehaviour mono);
    public void ExecuteState(bool atAttackDistance);
    public void UnInitilizeState();
}
