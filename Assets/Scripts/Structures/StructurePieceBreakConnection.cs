using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePieceBreakConnection : MonoBehaviour
{
    [SerializeField] GameObject mainStabilityPiece;
    [SerializeField] bool isBottomPiece;
    private void Start()
    {
        if(!isBottomPiece && mainStabilityPiece != null)
        {
            mainStabilityPiece.GetComponent<StructurePiece>().onDead += MakeMeFallOnConnectionLost;
            GetComponent<StructurePiece>().onDead += StopCheckingIfImDead;
        }
    }
    private void StopCheckingIfImDead()
    {
        mainStabilityPiece.GetComponent<StructurePiece>().onDead -= MakeMeFallOnConnectionLost;
    }
    private void MakeMeFallOnConnectionLost()
    {
        if (GetComponent<StructurePiece>() != null)
        {
            StructurePiece piece = GetComponent<StructurePiece>();
            piece.health = 0;
            piece.CheckIfDead();
        }
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(transform.position+GetComponent<BoxCollider>().center, rayDirection, Color.blue);
    }
}
