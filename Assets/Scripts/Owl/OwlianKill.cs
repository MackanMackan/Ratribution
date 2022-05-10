using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlianKill : MonoBehaviour, IDestructable
{
    float forceMagnitude = 2;
    OwlianAnimationHandler animHandler;
    AIStateMachine stateMachine;
    Rigidbody owlRigidBody;
    NavMeshAgent agent;
    [SerializeField] CapsuleCollider colTrigg;
    [SerializeField] CapsuleCollider col2;
    [SerializeField] List<GameObject> childList;
    [SerializeField] List<Rigidbody> rigidBodies;
    [SerializeField] GameObject root;
    [SerializeField] GameObject featherParticles;
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
        colTrigg.enabled = false;
        col2.enabled = false;
        featherParticles.SetActive(true);
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("OwlScream",transform.position,true);
        
        foreach (var child in childList)
        {
            child.transform.SetParent(root.transform);
        }     
    }

    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {
        owlRigidBody.AddForce(direction * Random.Range(2,5) * forceMagnitude, ForceMode.VelocityChange);
        foreach (var rb in rigidBodies)
        {
            rb.AddForce(direction * Random.Range(2, 5) * forceMagnitude, ForceMode.VelocityChange);
        }
        CullOnDeath();
    }

    public void CheckIfDead()
    {
        
    }

    public void DamageMe(int damage, GameObject recievedFrom)
    {
        ActivatePhysics();
        Vector3 direction = recievedFrom.transform.position - transform.position;
        direction.Normalize();
        direction.y = 6;
        AddForceInDirection(direction,forceMagnitude);
        OwlSpawn.spawnOwlcounter--;
    }

    public void GetHitDirection(Vector3 direction)
    {
        
    }
    void CullOnDeath()
    {
        Destroy(gameObject,15);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            featherParticles.SetActive(false);
        }
    }
}
