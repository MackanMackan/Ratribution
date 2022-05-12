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

        if (!bilboard)
        {
            transform.LookAt(vCamera.transform);

        }
        else
        {
            transform.rotation = vCamera.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}

