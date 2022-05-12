using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullOnDead : MonoBehaviour
{
    private int timeUntilCulled = 5;
    BuildingDestroy buildingDestroy;
    StructurePiece structurePiece;
    void Start()
    {
        //if(transform.childCount != 0)
        //{
        //    buildingDestroy = GetComponent<BuildingDestroy>();
        //    buildingDestroy.onDead += Cull;
        //}
        //else
        //{
            structurePiece = GetComponent<StructurePiece>();
            structurePiece.onDead += Cull;
       // }
    }

    public void Cull()
    {
        timeUntilCulled = Random.Range(0, 5);
        Destroy(gameObject, timeUntilCulled);
    }
}
