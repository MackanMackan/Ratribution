using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public delegate void onHit();
public delegate void onDead();
public delegate void onDamageBuilding(int damage);


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(CullOnDead))]
[RequireComponent(typeof(StructurePieceBreakConnection))]
public class StructurePiece : MonoBehaviour, IDestructable
{
    public int health = 100;

    public event onHit onHit;
    public event onDead onDead;
    public event onDamageBuilding onDamageBuilding;

    private MeshCollider meshCollider;
    private Rigidbody rigidBody;
    private GameObject latestHitRecievedFrom;
    private int forceMagnitude = 10;
    private bool isDead = false;
    Vector3 hitDir;

    private int particlesToEmit = 4;

    void Start()
    {
        onHit += CheckIfDead;
        meshCollider = GetComponent<MeshCollider>();
        rigidBody = GetComponent<Rigidbody>();
    }
    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {
        rigidBody.AddForce(direction * forceMagnitude, ForceMode.Impulse);
    }

    public void DamageMe(int damage, GameObject recievedFrom, int impactJumpAt)
    {
        if (isDead) { AddForceInDirection(hitDir, forceMagnitude); return; }
        health -= damage;
        latestHitRecievedFrom = recievedFrom;

        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(meshCollider.bounds.center, particlesToEmit);

        if(impactJumpAt < 1)
        {
            ServiceLocator.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, true);
        }

        onHit?.Invoke();
        onDamageBuilding?.Invoke(damage);
    }
    public void CheckIfDead()
    {
       if(health <= 0)
        {
            if(latestHitRecievedFrom == null)
            {
                hitDir = Vector3.zero;
            }
            else
            {
                hitDir = transform.position - latestHitRecievedFrom.transform.position;
            }
            ActivatePhysics();
            AddForceInDirection(hitDir, forceMagnitude);
            isDead = true;
            onDead?.Invoke();
        }
    }


    public void ActivatePhysics()
    {
        if (rigidBody == null) { return; }
        rigidBody.isKinematic = false;
        isDead = true;
        health = 0;
    }
    public void GetHitDirection(Vector3 hitDir)
    {
        this.hitDir = hitDir;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
        {
            ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(meshCollider.bounds.center, particlesToEmit);
        }
    }
}
