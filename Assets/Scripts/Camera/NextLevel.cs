using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera gateCam1;
    [SerializeField]
    CinemachineVirtualCamera gateCam2;
    [SerializeField]
    GameObject gate1;
    [SerializeField]
    GameObject gate2;

    GetBuildingHealth getLevelHealth;
    GlobalVolumeController globalVolumeController;
    CinemachineSwitch cinemachineSwitch;

    public GameObject winUI;

    float levelHealth;
    float speed = 10;

    bool level = true;
    

    private void Start()
    {
        globalVolumeController = FindObjectOfType<GlobalVolumeController>();
        getLevelHealth = FindObjectOfType<GetBuildingHealth>();
        cinemachineSwitch = FindObjectOfType<CinemachineSwitch>();
        winUI.SetActive(false);
        MotherTreeDestruction.onDestroyTree += WinGame;
    }

    private void Update()
    {
        if (getLevelHealth.level == Level.Level_2)
        {          
            GateOpen(gate1);

            if (level)
            {
                StartCoroutine(cinemachineSwitch.GateCamera(gateCam1));
                level = false;
            }
        }

        if ( getLevelHealth.level == Level.Level_3)
        {
            GateOpen(gate2);

            if (level == false)
            {
                StartCoroutine(cinemachineSwitch.GateCamera(gateCam2));
                level = true;
            }
        }

        if (Input.GetMouseButton(1))
        {
            WinGame();
        }
    }

    public void GateOpen(GameObject gate)
    {
        gate.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public void WinGame()
    {     
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.03F * Time.timeScale;

            StartCoroutine(WinGame2());            
    }

    public IEnumerator WinGame2() //TODO KAN MAN INTE LAGGA TILL IENUMERATORT TILL EVENTET?
    {
        yield return new WaitForSeconds(1.5f);
        winUI.SetActive(true);
        globalVolumeController.TurnOnBlurr();
    }

}
