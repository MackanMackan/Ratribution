using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullOnDead : MonoBehaviour
{
    private int timeUntilCulled = 5;
    StructurePiece structurePiece;
    void Start()
    {
        structurePiece = GetComponent<StructurePiece>();
        structurePiece.onDead += Cull;
        structurePiece.onPhysicsActive += Cull;
    }

    private void Cull()
    {
        Destroy(gameObject, timeUntilCulled);
    }
}
