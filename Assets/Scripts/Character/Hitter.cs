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

    public CinemachineShake cinemachineShake;
    void Start()
    {
        onHitDestructable += DamageDestructableObject;
        hitID = Random.Range(0, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DamageDestructableObject()
    {
        StartCoroutine(CalculateHitDirection());
        destructableObj.DamageMe(damage, hitID, gameObject,0);
        if (!hitSFXPlayed)
        {
            cinemachineShake.CMShake(0.1f, 0.1f, 0.5f);
            ServiceLocator.GetAudioProvider().PlayOneShot("StructureImpact",transform.position,true);
            hitSFXPlayed = true;
        }
    }
    IEnumerator CalculateHitDirection()
    {
        oldHitDir = transform.position;
        yield return new WaitForSeconds(0.1f);
        hitDir = oldHitDir - transform.position;
        hitDir.Normalize();
        destructableObj.GetHitDirection(hitDir);
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
