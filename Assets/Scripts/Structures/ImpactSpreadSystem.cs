using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSpreadSystem : MonoBehaviour
{
    public BoxCollider boxCollider;
    public GameObject testBox;
    public LayerMask layer;
    public bool testImpact = false;

    float impactSpreadDamageModifier = 0.60f;
    int impactJumpAt = 0;
    int maxImpactJumps = 2;
    Collider[] nearbyColliders;
    List<int> hitIDs = new List<int>();
    void Start()
    {
        GetComponent<StructurePiece>().onHit += GetNearbyStructurePieces;
        boxCollider = GetComponent<BoxCollider>();
    }

    private void GetNearbyStructurePieces(int hitID, int impactSpreadJumpAt, int damage)
    {
        impactJumpAt = impactSpreadJumpAt;
        if(impactJumpAt == maxImpactJumps) { return; }
        else
        {
            impactJumpAt++;
        }
        foreach (int id in hitIDs)
        {
            if (id == hitID) { return; }
        }
        hitIDs.Add(hitID);
        nearbyColliders = Physics.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.size/3 * 1.1f,
           Quaternion.identity, layer);

        SpreadImpactToNearbyPieces(damage, hitID);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //check that it is being run in play mode, so it doesn't try to draw this in editor mode
    //    if (true)
    //        //draw a cube where the overlapbox is (positioned where your gameobject is as well as a size)
    //        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size * 1.2f);
    //}
    private void SpreadImpactToNearbyPieces(int damage, int hitID)
    {
        damage = Mathf.RoundToInt((float)damage * impactSpreadDamageModifier);
        foreach (Collider nearbyObj in nearbyColliders)
        {
            if(nearbyObj == boxCollider) { continue; }
            if (testImpact)
            {
                GameObject instance = Instantiate(testBox);
                instance.transform.position = nearbyObj.transform.position;
                Destroy(instance, 2);
                Debug.DrawRay(transform.position, nearbyObj.transform.position - transform.position, Color.red, 10);
            }
            nearbyObj.GetComponent<IDestructable>().DamageMe(damage, hitID, gameObject, impactJumpAt);
        }
    }
}
