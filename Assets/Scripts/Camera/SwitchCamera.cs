using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera introCamera;
    public Camera mainCamera;

    public void IntroCamera()
    {
        mainCamera.enabled = false;
        introCamera.enabled = true;
    }

    public void MainCamera()
    {
        mainCamera.enabled = true;
        introCamera.enabled = false;
    }
}
