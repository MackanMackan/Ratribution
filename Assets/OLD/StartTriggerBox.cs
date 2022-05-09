using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTriggerBox : MonoBehaviour
{
    public GameObject UIObject;

    void Start()
    {
        UIObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIObject.SetActive(true);
            //StartCoroutine(DestroyUI());
        }
    }
    //IEnumerator DestroyUI()
    //{
    //    yield return new WaitForSeconds(5);
    //    Destroy(UIObject);
    //    Destroy(gameObject);
        
    //}


}
