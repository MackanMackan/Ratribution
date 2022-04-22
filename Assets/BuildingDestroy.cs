using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onGotHit(int hitID, int impactJumpAt, int damage);
public class BuildingDestroy : MonoBehaviour, IDestructable
{
    [SerializeField] private int health;
    public event onGotHit onGotHit;
    public event onDead onDead;

    private Rigidbody rigidBody;
    private GameObject latestHitRecievedFrom;
    private int forceMagnitude = 25;
    private bool isDead = false;
    Vector3 hitDir;

    private int particlesToEmit = 2;

    void Start()
    {
        onGotHit += CheckIfDead;
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

        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(transform.position, particlesToEmit);

        if (impactJumpAt < 1)
        {
            ServiceLocator.GetAudioProvider().PlayOneShot("ImpactAftermath", transform.position, true);
        }

        onGotHit?.Invoke(hitID, impactJumpAt, damage);
    }
    public void CheckIfDead(int hitID, int impactJumpAt, int damage)
    {
        if (health <= 0)
        {
            if (!latestHitRecievedFrom.gameObject.name.Equals("PlayerHitter"))
            {
                hitDir = latestHitRecievedFrom.transform.position - transform.position;
            }
            ActivatePhysics();
            AddForceInDirection(Vector3.up, forceMagnitude);
            isDead = true;
            onDead?.Invoke(transform);
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
}
