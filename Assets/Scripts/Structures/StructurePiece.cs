using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void onHit(int hitID, int impactJumpAt, int damage);
public delegate void onDead();
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(CullOnDead))]
[RequireComponent(typeof(ImpactSpreadSystem))]
public class StructurePiece : MonoBehaviour, IDestructable
{
    public int health = 100;

    public event onHit onHit;
    public event onDead onDead;

    private BoxCollider boxCollider;
    private Rigidbody rigidBody;
    private GameObject latestHitRecievedFrom;
    private int forceMagnitude = 10;
    private bool isDead = false;
    Vector3 hitDir;

    List<int> alreadyHitByHitID = new List<int>();
    void Start()
    {
        onHit += CheckIfDead;
        boxCollider = GetComponent<BoxCollider>();
        rigidBody = GetComponent<Rigidbody>();
    }
    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {
        rigidBody.AddForce(direction * forceMagnitude, ForceMode.Impulse);
    }

    public void DamageMe(int damage, int hitID, GameObject recievedFrom, int impactJumpAt)
    {
        if (isDead) { return; }
        health -= damage;
        latestHitRecievedFrom = recievedFrom;

        Debug.Log("ME: "+gameObject.name + "impact jump at: " +impactJumpAt + 
            "From: "+recievedFrom.name);
        DustParticleSystem.Instance.EmitDustParticles(transform.position, 1);

        if(impactJumpAt < 1)
        {
            ServiceLocator.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, true);
        }

        onHit?.Invoke(hitID, impactJumpAt, damage);
    }
    public void CheckIfDead(int hitID, int impactJumpAt, int damage)
    {
       if(health <= 0)
        {
            if (!latestHitRecievedFrom.gameObject.name.Equals("PlayerHitter"))
            {
                hitDir = latestHitRecievedFrom.transform.position - transform.position;
            }
            ActivatePhysics();
            AddForceInDirection(hitDir, forceMagnitude);
            isDead = true;
            onDead?.Invoke();
        }
    }


    public void ActivatePhysics()
    {
        boxCollider.isTrigger = false;
        rigidBody.useGravity = true;
    }
    public void GetHitDirection(Vector3 hitDir)
    {
        this.hitDir = hitDir;
    }
}
