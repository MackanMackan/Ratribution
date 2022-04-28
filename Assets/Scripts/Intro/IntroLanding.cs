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
    public IntroCameraShake introCameraShake;
    //public GameObject V_cam;
    public GameObject cameraHolder;
    //public DollyZoom dollyZoom;

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

            //dollyZoom.MoveDollyZoom();
        }
    }

     IEnumerator BeginGame ()
    {
        yield return new WaitForSeconds(3f);

        //cameraHolder.transform.position = Vector3.Lerp(cameraHolder.transform.position, FP_cam.transform.position,20f);

        //yield return new WaitForSeconds(2f);

        cinemachineVirtualCamera.enabled = true;
        trigger.enabled = false;
        landing = true;     
    }
}
