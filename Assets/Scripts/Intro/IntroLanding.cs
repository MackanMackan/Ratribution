using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroLanding : MonoBehaviour
{ 
    public CharacterMovement characterMovement;

    [HideInInspector]
    public bool landing;
    
    Collider trigger;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CinemachineVirtualCamera cinemachineVirtualCamera2;
    public IntroCameraShake introCameraShake;
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
        yield return new WaitForSeconds(0.5f);

        cinemachineVirtualCamera.enabled = true;
        cinemachineVirtualCamera2.enabled = true;
        trigger.enabled = false;
        landing = true;     
    }
}
