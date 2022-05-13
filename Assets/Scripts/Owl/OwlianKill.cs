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
    [SerializeField] GameObject root;
    [SerializeField] GameObject featherParticles;
    [SerializeField] GameObject featherPoofParticles;
    [SerializeField] GameObject owlSpear;
    [SerializeField] GameObject owlMesh;
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
       // col2.enabled = false;
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
        StartCoroutine(CullOnDeath());
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
    IEnumerator CullOnDeath()
    {
        yield return new WaitForSeconds(5);
        Instantiate(featherPoofParticles, root.transform.position,Quaternion.identity);
        owlMesh.SetActive(false);
        owlSpear.SetActive(false);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            featherParticles.SetActive(false);
        }
    }
}
