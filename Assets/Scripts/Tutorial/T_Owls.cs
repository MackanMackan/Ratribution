using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Owls : MonoBehaviour
{
    public GameObject owlPrefab;
    public GameObject instanciatePlace;
    [HideInInspector]
    public Vector3 instanciatePos;
    [HideInInspector]
    public GameObject owlClone;
    [HideInInspector]
    public bool isOwlAlive = false;
    bool stopOwl;
    int owlCounter;

    public void T_OwlSpawn()
    {
        if (stopOwl == false)
        {
            instanciatePos = instanciatePlace.transform.position;
            owlClone = Instantiate(owlPrefab, instanciatePos, Quaternion.identity);
            isOwlAlive = true;
            owlCounter++;
        }

        if ( owlCounter >=5)
        {
            isOwlAlive = true;
        }
    }
}
