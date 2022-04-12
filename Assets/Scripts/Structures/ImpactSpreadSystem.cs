using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSpreadSystem : MonoBehaviour
{
    List<StructurePiece> sturcturePieces = new List<StructurePiece>();
    Vector3 boxBounds;
    void Start()
    {
        GetComponent<StructurePiece>().onHit += GetNearbyStructurePieces;
        boxBounds = GetComponent<BoxCollider>().bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetNearbyStructurePieces()
    {
        Debug.LogError("Implement impact");
    }
}
