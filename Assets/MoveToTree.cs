using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.UI;

public class MoveToTree : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera treeCam;
    [SerializeField]
    CinemachineVirtualCamera cmCam;

    GameObject motherTree;
    GameObject player;
    BoxCollider boxCollider;

    [SerializeField]
    PauseMovment pauseMovment;
    [SerializeField]
    GameObject destroyUI;
    [SerializeField]
    GameObject treeUI;

    public Image barrel1;
    public Image barrel2;
    public Image barrel3;

    MotherTreeDestruction motherTreeDestruction;
    private void Awake()
    {
        treeCam.enabled = false;
        treeUI.SetActive(false);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        motherTree = GameObject.FindGameObjectWithTag("MotherTree");
        boxCollider = GetComponent<BoxCollider>();
        
        barrel3.color = barrel1.color = barrel2.color -= new Color(0, 0, 0, 0.5f);
        motherTreeDestruction = FindObjectOfType<MotherTreeDestruction>();

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
        pauseMovment.StopMovment(false);
        destroyUI.SetActive(false);
        treeUI.SetActive(true);

        yield return new WaitForSeconds(2);

        treeCam.enabled = false;
        cmCam.enabled = true;
        boxCollider.enabled = false;
        pauseMovment.StopMovment(true);
    }

    private void Update()
    {      
        if (motherTreeDestruction.amountOfBarrelsAttached == 1)
        {
            barrel1.color = Color.white;
        }

        if (motherTreeDestruction.amountOfBarrelsAttached == 2)
        {
            barrel2.color = Color.white;
        }

        if (motherTreeDestruction.amountOfBarrelsAttached == 3)
        {
            barrel3.color = Color.white;
        }
    }
}
