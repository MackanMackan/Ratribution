using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputOffset : MonoBehaviour
{
    private PlayerInputActions playerControls;
    CinemachineVirtualCamera vCam;
    CharacterMovement characterMovement;
    public Vector3 transposer;
    public float z;
    public float y;
    CinemachineVirtualCamera cam1;

    private void Awake()
    {       
            playerControls = new PlayerInputActions();       
    }
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        characterMovement = FindObjectOfType<CharacterMovement>();

        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        z = vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z;
        y = vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y;


    }

    public void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControls.Player.Camera.triggered)
        {
            StartCoroutine(blabla());
            Debug.Log(characterMovement.GetMoveInput());
        }
    }

    IEnumerator blabla()
    {

        Debug.Log("Hallå");
        vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(characterMovement.GetMoveInput().x *10, 10 * 10,z);
        yield return new WaitForSeconds(2);
        vCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = transposer;
    }
}
