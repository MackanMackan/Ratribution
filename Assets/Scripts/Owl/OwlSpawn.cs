using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSpawn : MonoBehaviour
{
    public GameObject owl;

    int maxOwl = 70;
    public static int spawnOwlcounter;
    float nextSpawn;
    public float spawnRate;

    public List<Transform> spawnPositionList = new List<Transform>();
    List<GameObject> numberOfOwls = new List<GameObject>();

    private GameObject[] beginOwls;

    GetBuildingHealth getLevelHealth;

    void Start()
    {
        addOwls();
        getLevelHealth = FindObjectOfType<GetBuildingHealth>();
    }

    private void addOwls()
    {
        beginOwls = GameObject.FindGameObjectsWithTag("Owlian");

        for (int i = 0; i < beginOwls.Length; i++)
        {
            numberOfOwls.Add(beginOwls[i]);
        }
    }
    void Update()
    {
        SpawnOwl();

        if (getLevelHealth.level == Level.Level_4 || Input.GetMouseButtonDown(1))
        {
            KillOwl();
            maxOwl = 0;
        }
    }

    private void SpawnOwl()

    {
        if (Time.time > nextSpawn && spawnOwlcounter < maxOwl)
        {
            nextSpawn = Time.time + spawnRate;
            Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
            
            GameObject enemySpawn = Instantiate(owl, spawnPosition, Quaternion.identity);
            spawnOwlcounter++;

            numberOfOwls.Add(enemySpawn);
        }
    }

    private void KillOwl()
    {
        foreach (GameObject owl in numberOfOwls)
        {
            Destroy(owl);
        }
    }
}

    
