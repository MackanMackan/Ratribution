using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BuildingCrumble : MonoBehaviour
{
    public int health;
    [SerializeField] List<Transform> children;
    [SerializeField] List<Transform> nonImporatantChildren;
    [SerializeField] [Range(0, 1)] float precentageToImmediatleyDestroy = 0;
    
    float amplitude = 2;
    
    float frequency = 2;
    
    float time = 0.4f;
    void Start()
    {
        foreach (var deadChild in nonImporatantChildren)
        {
            children.Remove(deadChild);
        }

        foreach (var child in children)
        {
            try
            {
                child.GetComponent<StructurePiece>().onDamageBuilding += DamageMe;
                
            }
            catch
            {
                Debug.LogError("NOTFOUND");
                nonImporatantChildren.Add(child);
            }
        }  
    }

    public void DamageMe(int damage)
    {
        damage = Mathf.Min(health, damage);

        health -= damage;
        if (health <= 0)
        {
            ServiceLocator.Instance.GetAudioProvider().PlayOneShot("StructureImpact", transform.position, true);
            DestroyBuilding();
        }
    }
    private void DestroyBuilding()
    {
        //For optimizing destruction
        for (int i = 1; i <  Mathf.RoundToInt(children.Count * precentageToImmediatleyDestroy); i++)
        {
            int pos = Random.Range(0, children.Count);
            if(children[pos] == null){ continue; }

            GameObject destoryThisPiece = children[pos].gameObject;
            children.Remove(children[pos]);
            Destroy(destoryThisPiece);
        }

        foreach(Transform child in children)
        {
            if(child == null) { continue; }

            child.GetComponent<StructurePiece>().ActivatePhysics();
            child.GetComponent<CullOnDead>().Cull();
        }
        NavMeshObstacle obs = GetComponent<NavMeshObstacle>();
        obs.carving = false;

        //CinemachineShake.Instance.BeginShake(amplitude, frequency, time);

        Destroy(gameObject, 10);
    }
}
