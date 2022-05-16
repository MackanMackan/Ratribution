using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlSpawn : MonoBehaviour
{
    public GameObject owl;
    public GameObject owl2;
    public GameObject owl3;

    int maxOwl = 70;
    float nextSpawn;
    float minScale = 1;
    float maxScale = 1.5f;

    public int spawnRate;
    public float spawnTimer;
    public static int spawnOwlcounter;

    public GameObject spawnManager;
    public List<Transform> spawnPositionList = new List<Transform>();
    public List<Transform> spawnPositionList2 = new List<Transform>();
    public List<Transform> spawnPositionList3 = new List<Transform>();

    [HideInInspector]
    public List<GameObject> numberOfOwls = new List<GameObject>();

    private GameObject[] owlsLevel1;
    private GameObject[] owlsLevel2;
    private GameObject[] owlsLevel3;

    GetBuildingHealth getLevelHealth;

    bool  newOwls = true;

    private void Awake()
    {
        nextSpawn = spawnTimer;
        getLevelHealth = FindObjectOfType<GetBuildingHealth>();

        owlsLevel1 = GameObject.FindGameObjectsWithTag("Owlian");
        owlsLevel2 = GameObject.FindGameObjectsWithTag("Owlian2");
        owlsLevel3 = GameObject.FindGameObjectsWithTag("Owlian3");
   
        Debug.Log(owlsLevel2);
       
        addOwls(owlsLevel1);
        DisableOwls(owlsLevel2);
        DisableOwls(owlsLevel3);
        Debug.Log(owlsLevel2);
    }

    private void addOwls(GameObject [] owls)
    {
        
        for (int i = 0; i < owls.Length; i++)
        {
            numberOfOwls.Add(owls[i]);
        }
    }
    void Update()
    {

        switch (getLevelHealth.level)
        {
            case Level.Level_1: SpawnOwl(spawnPositionList, owl); break;

            case Level.Level_2:
         
                SpawnOwl(spawnPositionList2, owl2);

                if (newOwls)

                {                  
                    ActivateOwls(owlsLevel2);
                    addOwls(owlsLevel2);

                    newOwls = false;
                }
                break;

            case Level.Level_3:
                SpawnOwl(spawnPositionList3, owl3);

                if (newOwls == false)
                {                   
                    ActivateOwls(owlsLevel3);
                    addOwls(owlsLevel3);

                    newOwls = true;
                }
                break;

            case Level.Level_4:

                KillOwl();
                spawnManager.SetActive(false);
                break;
        }
    }

    private void ActivateOwls(GameObject[] activeOwls)
    {
        for (int i = 0; i < activeOwls.Length; i++)
        {
            activeOwls[i].SetActive(true);            
        }
    }

    private void DisableOwls(GameObject[] activeOwls)
    {
        for (int i = 0; i < activeOwls.Length; i++)
        {
            activeOwls[i].SetActive(false);           
        }
    }

    private void SpawnOwl(List<Transform> spawnList, GameObject owlsLevel)

    {
        if (Time.time > nextSpawn)
        {          
            nextSpawn = Time.time + spawnTimer;
            Vector3 spawnArea = spawnList[Random.Range(0, spawnPositionList.Count)].position;
            Vector3 spawnPosition;
            ServiceLocator.Instance.GetAudioProvider().PlayOneShot("WarTrumpet",spawnArea, false);
            for (int i = 0; i < spawnRate; i++)
            {
                spawnPosition = spawnArea + new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
                GameObject enemySpawn = Instantiate(owlsLevel, spawnPosition, Quaternion.identity);
                enemySpawn.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
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

    
