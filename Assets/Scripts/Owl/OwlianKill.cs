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
    bool isDead = false;
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
        if(Random.Range(0,20) == 0)
            switch(Random.Range(0, 2))
            {
                case 0:   
                    ServiceLocator.Instance.GetAudioProvider().PlayOneShot("OwlScream",transform.position,true);
                    break;
                case 1:
                    ServiceLocator.Instance.GetAudioProvider().PlayOneShot("OwlScream2", transform.position, true);
                    break;
            }
        
        foreach (var child in childList)
        {
            child.transform.SetParent(root.transform);
        }     
    }

    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {
        owlRigidBody.AddForce(direction * Random.Range(2,5) * forceMagnitude, ForceMode.VelocityChange);
        owlRigidBody.angularVelocity = new Vector3(Random.Range(0.5f,3f), Random.Range(0.5f, 3f), Random.Range(0.5f, 3f));
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
        isDead = true;
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

    public bool AmIDead()
    {
        return isDead;
    }
}
