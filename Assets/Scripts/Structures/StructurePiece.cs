using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void onHit(int hitID);
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

    public void DamageMe(int damage, int hitID, GameObject recievedFrom)
    {
        if (isDead) { return; }
        health -= damage;
        onHit?.Invoke(hitID);
    }
    public void CheckIfDead(int hitID)
    {
       if(health <= 0)
        {
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
