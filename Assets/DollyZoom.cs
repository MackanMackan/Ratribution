using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DollyZoom : MonoBehaviour
{
    private Camera dollyCamera;
    //private GameObject target;
    private float dollySpeed = 5;
    private float initialFrustumHeight;
    public GameObject target;
    private void Awake()
    {
        Initialize();
        
    }

    private void Start()
    {
        
    }

    private void Initialize()
    {
        dollyCamera = GetComponent<Camera>();
        float distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
        initialFrustumHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    void Update()
    {
        //dolly
        transform.Translate(Input.GetAxis("Vertical")*(Vector3.forward * Time.deltaTime * dollySpeed));

        //zoom
        float currentDistance = Vector3.Distance(transform.position, target.transform.position);
        dollyCamera.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
    }

    //public void MoveDollyZoom()
    //{
    //    //dolly
    //    transform.Translate(Vector3.forward * Time.deltaTime * dollySpeed);

    //    ////zoom
    //    //float currentDistance = Vector3.Distance(transform.position,target.transform.position);
    //    //dollyCamera.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
    //}

    private float ComputeFrustumHeight(float distance)
    {
        return 2 * distance * Mathf.Tan(dollyCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    private float ComputeFieldOfView(float height, float distance)
    {
        return 2 * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg;
    }
}
