using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Instanciate : MonoBehaviour
{
    public GameObject UIObject;
    public GameObject prefab;
    public GameObject instanciatePlace;
    [HideInInspector]
    public Vector3 blabla;
    [HideInInspector]
    public GameObject bla;
    [HideInInspector]
    public bool test;

    void Start()
    {
        UIObject.SetActive(false);
        blabla = instanciatePlace.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIObject.SetActive(true);
            bla= Instantiate(prefab, blabla, Quaternion.identity);
            test = true;

        }
    }

    private void Update()
    {
        if (bla == null && test)
        {
            Destroy(UIObject);
            Destroy(gameObject);
        }
    }


}
