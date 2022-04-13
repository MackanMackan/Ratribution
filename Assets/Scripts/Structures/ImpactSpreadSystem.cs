using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSpreadSystem : MonoBehaviour
{
    public GameObject testBox;
    BoxCollider boxCollider;
    Collider[] nearbyColliders;
    List<int> hitIDs = new List<int>();
    int overlapBoxSizeMultiplier = 3;
    void Start()
    {
        GetComponent<StructurePiece>().onHit += GetNearbyStructurePieces;
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetNearbyStructurePieces(int hitID)
    {
        foreach(int id in hitIDs)
        {
            if (id == hitID) { return; }
        }
        hitIDs.Add(hitID);
        Debug.LogError("Implement impact");
        nearbyColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2,
            Quaternion.identity, LayerMask.NameToLayer("Default"));

        Debug.Log(nearbyColliders.Length);
        SpreadImpactToNearbyPieces();
    }
    private void SpreadImpactToNearbyPieces()
    {
        //if(nearbyColliders.Length == 0)
        //{
        //    StructurePiece[] pieces = transform.parent.GetComponentsInChildren<StructurePiece>();
        //    foreach(StructurePiece piece in pieces)
        //    {
        //        piece.ActivatePhysics();
        //    }
        //    return;
        //}
        foreach (Collider nearbyObj in nearbyColliders)
        {
            Debug.Log(nearbyObj.gameObject.name);
            //BoxCollider newCollider = nearbyObj.gameObject.AddComponent<BoxCollider>();
            //newCollider.bounds.center.Set(boxCollider.bounds.center.x, boxCollider.bounds.center.y, boxCollider.bounds.center.z);
            //newCollider.bounds.extents.Set(boxCollider.bounds.extents.x * 1.2f,
            //boxCollider.bounds.extents.y * 1.2f, boxCollider.bounds.extents.z * 1.2f);
            nearbyObj.GetComponent<IDestructable>().DamageMe(10, hitIDs[hitIDs.Count-1], gameObject);
        }
    }
}
