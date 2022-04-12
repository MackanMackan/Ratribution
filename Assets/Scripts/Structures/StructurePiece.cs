using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHit();
public class StructurePiece : MonoBehaviour, IDestructable
{
    public int health = 100;

    public static event onHit onHit;

    private BoxCollider boxCollider;
    private Rigidbody rigidBody;
    private int forceMagnitude = 10;
    private bool isDead;
    Vector3 hitDir;
    public void AddForceInDirection(Vector3 direction, float forceMagnitude)
    {
        rigidBody.AddForce(direction * forceMagnitude, ForceMode.Impulse);
    }

    public void DamageMe(int damage)
    {
        if (isDead) { return; }
        health -= damage;
        ImpactNearbyPieces();
        Debug.Log(gameObject.name + ": HIT!");
        onHit?.Invoke();
    }

    public void ImpactNearbyPieces()
    {
        Debug.LogError("Implement impact");
    }

    public void CheckIfDead()
    {
       if(isDead){ return; }
       if(health <= 0)
        {
            ActivatePhysics();
            AddForceInDirection(hitDir, forceMagnitude);
            isDead = true;
        }
    }


    public void ActivatePhysics()
    {
        boxCollider.isTrigger = false;
        rigidBody.useGravity = true;
    }
    // Start is called before the first frame update
    public void GetHitDirection(Vector3 hitDir)
    {
        this.hitDir = hitDir;
    }
    void Start()
    {
        onHit += CheckIfDead;
        boxCollider = GetComponent<BoxCollider>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
