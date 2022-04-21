using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructurePieceBreakConnection : MonoBehaviour
{
    [SerializeField] Vector3 rayDirection = new Vector3(0,0,0);
    [SerializeField] string connectedPieceName;
    void Start()
    {
        //Shoot a raycast to get the closest downward piece this is connected to
        rayDirection.Normalize();
        GetDownwardPiece();
        //Connect to a isDead Event and activate physics on this piece too
    }
     private void GetDownwardPiece()
    {
        int i = 0;
        RaycastHit[] hitInfo;

        hitInfo = Physics.RaycastAll(transform.position + GetComponent<BoxCollider>().center, rayDirection, 3);
        if(hitInfo.Length == 0) { return; }
        if (hitInfo[i].transform.gameObject.name.Equals(gameObject.name)) { i++;  }

            if (hitInfo[i].transform.gameObject.layer == LayerMask.NameToLayer("Destructable"))
            {
                ConnectMeToUnderLyingPiece(hitInfo[i].transform.gameObject);
            }
    }
    private void ConnectMeToUnderLyingPiece(GameObject underLyingPiece)
    {
        connectedPieceName = underLyingPiece.name;
        underLyingPiece.GetComponent<StructurePiece>().onPhysicsActive += GetComponent<StructurePiece>().ActivatePhysicsNotDead;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position+GetComponent<BoxCollider>().center, rayDirection, Color.blue);
    }
}
