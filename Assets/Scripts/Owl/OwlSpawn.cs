using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSpawn : MonoBehaviour
{
    public GameObject owl;
    public GameObject startPoint;

    int maxOwl = 350;
    int spawnOwlcounter;
    float nextSpawn;
    public float spawnRate;

    public List<Transform> spawnPositionList = new List<Transform>();
    List<GameObject> numberOfOwls = new List<GameObject>();

    private GameObject[] beginOwls;

    void Start()
    {
        addOwls();
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

        Debug.Log(numberOfOwls.Count);
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
}
    
