using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowIntro : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        target = GameObject.Find("Player(Clone)").GetComponent<Transform>();
    }

    void Update()
    {       
        transform.LookAt(target);      
    }

    //TODO ZOOMA?
}
