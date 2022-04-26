using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHitDestructable();
public class Hitter : MonoBehaviour
{
    public event onHitDestructable onHitDestructable;
    public int damage = 40;
    public float gizmoSizeSplit = 1f;

    Vector3 hitDir;
    Vector3 oldHitDir;

    private IDestructable destructableObj;
    private int hitID = 0;
    private bool hitSFXPlayed = false;

     float amplitude= 5f;
     float frequency= 2f;
     float time =0.4f;

    void Start()
    {
        onHitDestructable += DamageDestructableObject;
    }
    void DamageDestructableObject()
    {
        destructableObj.DamageMe(damage, gameObject,0);
        if (!hitSFXPlayed)
        {
            CinemachineShake.Instance.BeginShake(amplitude, frequency, time);
            ServiceLocator.GetAudioProvider().PlayOneShot("StructureImpact",transform.position,true);
            hitSFXPlayed = true;
        }
    }

    public void GetNewHitID()
    {
        hitID = Random.Range(0, 10000);
        hitSFXPlayed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDestructable>() != null)
        {                   
            destructableObj = other.GetComponent<IDestructable>();
            //TODO: REDO impact effect it sux //by kolbe for kolbe
           // ParticleSystemServiceLocator.Instance.GetImpactParticleSystem().EmitParticles(transform.position, 1);
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
