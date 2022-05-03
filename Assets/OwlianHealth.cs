using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlianHealth : MonoBehaviour, IDestructable
{
    float forceMagnitude = 2;
    OwlianAnimationHandler animHandler;
    AIStateMachine stateMachine;
    Rigidbody owlRigidBody;
    NavMeshAgent agent;
    void Start()
    {
        animHandler = GetComponent<OwlianAnimationHandler>();
        owlRigidBody = GetComponent<Rigidbody>();
        stateMachine = GetComponent<AIStateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void ActivatePhysics()
    {
        agent.enabled = false;
        stateMachine.enabled = false;
        owlRigidBody.isKinematic = false;
        animHandler.DisableAnimator();
    }

    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {

        owlRigidBody.AddForce(direction * Random.Range(1,4), ForceMode.VelocityChange);
    }

    public void CheckIfDead()
    {
        
    }

    public void DamageMe(int damage, GameObject recievedFrom)
    {
        ActivatePhysics();
        Vector3 direction = recievedFrom.transform.position - transform.position;
        direction.Normalize();
        direction.y = 3;
        AddForceInDirection(direction,forceMagnitude);
    }

    public void GetHitDirection(Vector3 direction)
    {
        
    }

}
