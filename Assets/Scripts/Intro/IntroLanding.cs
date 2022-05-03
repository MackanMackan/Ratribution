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
    public CinemachineVirtualCamera cinemachineVirtualCameraIntro;

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

        cinemachineVirtualCamera.enabled = true;
        CinemachineShake.Instance.cam1 = cinemachineVirtualCamera;
        cinemachineVirtualCamera2.enabled = true;
        cinemachineVirtualCameraIntro.enabled = false;
        trigger.enabled = false;
        landing = true;
    }
}
