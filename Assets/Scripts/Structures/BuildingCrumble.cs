using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildingCrumble : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] List<Transform> children;
    void Start()
    {   
        foreach (var child in children)
        {
            child.GetComponent<StructurePiece>().onDamageBuilding += DamageMe;
        }
    }

    public void DamageMe(int damage)
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
        NavMeshObstacle obs = GetComponent<NavMeshObstacle>();
        obs.carving = false;
        
        Destroy(gameObject, 10);
    }
}
