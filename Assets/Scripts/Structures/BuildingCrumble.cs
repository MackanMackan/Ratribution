using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildingCrumble : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] List<Transform> children;
    DestructionCount destructionCount;
   
    float amplitude = 2;
    
    float frequency = 2;
    
    float time = 0.4f;
    void Start()
    {   
        foreach (var child in children)
        {
            child.GetComponent<StructurePiece>().onDamageBuilding += DamageMe;
        }

        destructionCount = FindObjectOfType<DestructionCount>();
        destructionCount.AddHealth(health);
        
    }

    public void DamageMe(int damage)
    {
        damage = Mathf.Min(health, damage);

        health -= damage;

        //destructionCount.UpdateUIText(damage);
        destructionCount.UpdateUISlider(damage);

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
