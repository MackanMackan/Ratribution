using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_InstanciateTower : MonoBehaviour
{
    public GameObject towerPrefab;
    public GameObject instanciatePlace;
    [HideInInspector]
    public Vector3 instanciatePos;
    [HideInInspector]
    public GameObject towerClone;
    [HideInInspector]
    public bool isTowerAlive = false;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void T_Building()
    {
        if (isTowerAlive == false)
        {
            instanciatePos = instanciatePlace.transform.position;
            towerClone = Instantiate(towerPrefab, instanciatePos, Quaternion.identity);
            isTowerAlive = true;
        }   
    }
}
