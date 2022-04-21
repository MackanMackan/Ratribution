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
        nearbyColliders = new Collider[0];
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

        if(nearbyColliders.Length == 0) { GetComponent<StructurePiece>().ActivatePhysics(); return; }

        StartCoroutine(SpreadImpactToNearbyPieces(damage, hitID));
    }
    IEnumerator SpreadImpactToNearbyPieces(int damage, int hitID)
    {
        yield return new WaitForSeconds(0.25f);
        damage = Mathf.RoundToInt((float)damage * impactSpreadDamageModifier);
        foreach (Collider nearbyObj in nearbyColliders)
        {
            if(nearbyObj == boxCollider) { continue; }
            /*if (testImpact)
            {
                GameObject instance = Instantiate(testBox);
                instance.transform.position = nearbyObj.transform.position;
                Destroy(instance, 2);
                Debug.DrawRay(transform.position, nearbyObj.transform.position - transform.position, Color.red, 10);
            }*/
            nearbyObj.GetComponent<IDestructable>().DamageMe(damage, hitID, gameObject, impactJumpAt);
        }
    }
}
