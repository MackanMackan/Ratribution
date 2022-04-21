using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrumble : MonoBehaviour
{
    [SerializeField] int health;
    void Start()
    {
        StructurePiece.onHitStructure += HurtMe;
    }

    private void HurtMe(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DestroyBuilding();
        }
    }
    private void DestroyBuilding()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<StructurePiece>().ActivatePhysics();
        }
    }
}
