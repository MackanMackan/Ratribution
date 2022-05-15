using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHitDestructable();
public class Hitter : MonoBehaviour
{
    public event onHitDestructable onHitDestructable;
    public int damage = 40;
    public float gizmoSizeSplit = 1f;

    [SerializeField] private CharacterAnimationImpact animImpact;
    [SerializeField] ParticleSystem shockWaveParticleSystem;
    private IDestructable destructableObj;
    Transform playerTransform;
 
    void Start()
    {
        onHitDestructable += DamageDestructableObject;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void DamageDestructableObject()
    {
        if (!gameObject.transform.parent.CompareTag("Pickup"))
        {
            if(!destructableObj.AmIDead())
                switch (Random.Range(0, 2))
                {
                    case 0:
                        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("OwlHit", transform.position, true);
                        break;
                    case 1:
                        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("OwlHit2", transform.position, true);
                        break;
                }
        }
        destructableObj.DamageMe(damage, gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDestructable>() != null)
        {
            destructableObj = other.GetComponent<IDestructable>();

            if (gameObject.transform.parent.CompareTag("Player") || gameObject.transform.parent.CompareTag("PlayerLimb"))
                animImpact.PauseAnimationOnImpact(playerTransform,transform);

            onHitDestructable?.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.GetComponent<SphereCollider>().bounds.center, gameObject.GetComponent<SphereCollider>().radius / gizmoSizeSplit);
    }
}
