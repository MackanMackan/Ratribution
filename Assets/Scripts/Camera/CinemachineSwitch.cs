using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitch : MonoBehaviour
{
    [SerializeField]
    private InputAction action;
    [SerializeField]
    private CinemachineVirtualCamera vCam1;
    [SerializeField]
    private CinemachineVirtualCamera vCam2;

    private bool cam1 = true;

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.performed += _ => SwitchCameraPrio();
    }

    private void SwitchCameraPrio()
    {
        if (cam1)
        {
            vCam1.Priority = 0;
            vCam2.Priority = 1;
            CinemachineShake.Instance.cam1 = vCam2;
        }

        else
        {
            vCam1.Priority = 1;
            vCam2.Priority = 0;
            CinemachineShake.Instance.cam1 = vCam1;
        }

        cam1 = !cam1;
    }
}
