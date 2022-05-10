using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSpawn : MonoBehaviour
{
    public GameObject owl;

    int maxOwl = 70;
    public static int spawnOwlcounter;
    float nextSpawn;
    public int spawnRate;
    public float spawnTimer;

    public List<Transform> spawnPositionList = new List<Transform>();
    [HideInInspector]
    public List<GameObject> numberOfOwls = new List<GameObject>();

    private GameObject[] beginOwls;

    GetBuildingHealth getLevelHealth;

    void Start()
    {
        nextSpawn = spawnTimer;
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

        if (getLevelHealth.level == Level.Level_4)
        {
            KillOwl();
            maxOwl = 0;
        }
    }

    private void SpawnOwl()

    {
        if (Time.time > nextSpawn)
        {
            
            nextSpawn = Time.time + spawnTimer;
            Vector3 spawnArea = spawnPositionList[Random.Range(0, spawnPositionList.Count)].position;
            Vector3 spawnPosition;
            ServiceLocator.Instance.GetAudioProvider().PlayOneShot("WarTrumpet",spawnArea, false);
            for (int i = 0; i < spawnRate; i++)
            {
                spawnPosition = spawnArea + new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
                GameObject enemySpawn = Instantiate(owl, spawnPosition, Quaternion.identity);
                spawnOwlcounter++;
                numberOfOwls.Add(enemySpawn);
            }
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

    
