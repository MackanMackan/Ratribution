using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveToTree : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera treeCam;
    [SerializeField]
    CinemachineVirtualCamera cmCam;
    GameObject motherTree;
    GameObject player;
    BoxCollider boxCollider;

    private void Awake()
    {
        treeCam.enabled = false;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        motherTree = GameObject.FindGameObjectWithTag("MotherTree");
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CamToTree());
        }
    }

    IEnumerator CamToTree()
    {
        treeCam.enabled = true;
        cmCam.enabled = false;

        yield return new WaitForSeconds(2);

        treeCam.enabled = false;
        cmCam.enabled = true;
        boxCollider.enabled = false;
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        StartCoroutine(CamToTree());
    //    }
    //}
}
