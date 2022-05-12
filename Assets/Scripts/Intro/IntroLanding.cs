using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroLanding : MonoBehaviour
{
    [HideInInspector]
    public bool landing;

    Collider trigger;
    public CinemachineVirtualCamera cinemachineVirtualCamera2;
    public CinemachineVirtualCamera cinemachineVirtualCameraIntro;

    
    public CharacterMovement characterMovement;

    private void Start()
    {
        trigger = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CinemachineShake.Instance.BeginShake(2, 2, 0.5f);
            StartCoroutine(BeginGame());
        }
    }

    IEnumerator BeginGame()
    {

        yield return new WaitForSeconds(2.75f);

        cinemachineVirtualCamera2.enabled = true;
        CinemachineShake.Instance.cam1 = cinemachineVirtualCamera2;
        cinemachineVirtualCameraIntro.enabled = false;
        trigger.enabled = false;

        yield return new WaitForSeconds(2f);

        landing = true;
             
    }
}
