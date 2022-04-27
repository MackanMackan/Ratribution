using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public interface IAIState
{
    public void InitializeState(NavMeshAgent agent,GameObject player, MonoBehaviour mono);
    public void ExecuteState();
    public void UnInitilizeState();
}
