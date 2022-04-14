using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHitDestructable();
public class Hitter : MonoBehaviour
{
    public event onHitDestructable onHitDestructable;
    public int damage = 40;

    Vector3 hitDir;
    Vector3 oldHitDir;

    private IDestructable destructableObj;
    private int hitID;
    void Start()
    {
        onHitDestructable += DamageDestructableObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DamageDestructableObject()
    {
        StartCoroutine(CalculateHitDirection());
        int hitID = Random.Range(0, 10000);
        destructableObj.DamageMe(damage, hitID, gameObject,0);
    }
    IEnumerator CalculateHitDirection()
    {
        oldHitDir = transform.position;
        yield return new WaitForSeconds(0.1f);
        hitDir = oldHitDir - transform.position;
        hitDir.Normalize();
        destructableObj.GetHitDirection(hitDir);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDestructable>() != null)
        {
            destructableObj = other.GetComponent<IDestructable>();
            onHitDestructable?.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.GetComponent<SphereCollider>().bounds.center, 2.991732f /2 );
    }
}
