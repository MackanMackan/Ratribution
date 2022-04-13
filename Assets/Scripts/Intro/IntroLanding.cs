using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLanding : MonoBehaviour
{ 
    public IntroCameraShake cameraShake;
    public SwitchCamera switchCamera;
    public CharacterMovement characterMovement;
    public bool landing;
    
    Collider trigger;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(cameraShake.Shake(.25f, .8f));
            StartCoroutine(CameraSwith());
        }
    }

    public IEnumerator CameraSwith()
    {
        yield return new WaitForSeconds(1.5f);
        trigger.enabled = false;
        switchCamera.MainCamera();
        landing = true;
    }
}
