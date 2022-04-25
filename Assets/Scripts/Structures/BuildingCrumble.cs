using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrumble : MonoBehaviour
{
    [SerializeField] int health;
    List<Transform> children;
    void Start()
    {
        StructurePiece piece;
        children = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
        foreach (Transform child in children)
        {
            piece = child.GetComponent<StructurePiece>();
        }

    }

    public void DamageMe(int hitID, int impactJumpAt, int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyBuilding();
        }
    }
    private void DestroyBuilding()
    {
        foreach(Transform child in children)
        {
            if(child == null) { continue; }

            child.GetComponent<StructurePiece>().ActivatePhysics();
            child.GetComponent<CullOnDead>().Cull();
        }
    }
    private void RemoveDeadPiece(Transform deadPiece)
    {
        children.Remove(deadPiece);
    }
}
