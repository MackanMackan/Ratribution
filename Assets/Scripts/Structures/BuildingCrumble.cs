using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildingCrumble : MonoBehaviour
{
    public int health;
    [SerializeField] List<Transform> children;
    
    float amplitude = 2;
    
    float frequency = 2;
    
    float time = 0.4f;
    void Start()
    {   
        foreach (var child in children)
        {
            child.GetComponent<StructurePiece>().onDamageBuilding += DamageMe;
        }                                 
    }

    public void DamageMe(int damage)
    {
        damage = Mathf.Min(health, damage);

        health -= damage;

        if (health <= 0)
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

        CinemachineShake.Instance.BeginShake(amplitude, frequency, time);

        Destroy(gameObject, 10);
    }
}
