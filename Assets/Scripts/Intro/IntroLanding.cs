using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroLanding : MonoBehaviour
{ 
    public CharacterMovement characterMovement;
    public bool landing;
    
    Collider trigger;
    public CinemachineFreeLook cinemachineFreeLook;
    public IntroCameraShake introCameraShake;
    public GameObject FP_cam;
    public GameObject cameraHolder;

    private void Start()
    {       
        trigger = GetComponent<BoxCollider>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(introCameraShake.Shake(0.25f, 0.25f));      
            StartCoroutine(BeginGame());
        }
    }

     IEnumerator BeginGame ()
    {
        yield return new WaitForSeconds(1f);

        //cameraHolder.transform.position = Vector3.Lerp(cameraHolder.transform.position, FP_cam.transform.position,20f);

        //yield return new WaitForSeconds(2f);

        cinemachineFreeLook.enabled = true;
        trigger.enabled = false;
        landing = true;     
    }
}
