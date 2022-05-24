using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bilboard : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;
    public bool bilboard;
 
    private void LateUpdate()
    {
        Vector3 targetPostition = new Vector3(vCamera.transform.position.x, transform.position.y, vCamera.transform.position.z);

        if (!bilboard)
        {
            transform.LookAt(targetPostition);

        }
        else
        {
            transform.rotation = vCamera.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

}

