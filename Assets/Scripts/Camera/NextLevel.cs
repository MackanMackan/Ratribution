using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera gateCam1;
    [SerializeField]
    CinemachineVirtualCamera gateCam2;
    [SerializeField]
    CinemachineVirtualCamera cam;
    [SerializeField]
    CinemachineVirtualCamera treeCam;

    [SerializeField]
    Animator gate1;
    [SerializeField]
    Animator gate2;
    [SerializeField]
    Animator gate3;
    [SerializeField]
    Animator gate4;

    public  GameObject itemsButton;

    GetBuildingHealth getLevelHealth;
    GlobalVolumeController globalVolumeController;
    CinemachineSwitch cinemachineSwitch;

    public GameObject winUI;

    float levelHealth;
    float speed = 10;

    bool level = true;
    bool level2GatesOpened = false;
    bool level3GatesOpened = false;
    EventSystem m_EventSystem;

    PausMenu pausMenu;
    private void Start()
    {
        globalVolumeController = FindObjectOfType<GlobalVolumeController>();
        pausMenu = FindObjectOfType<PausMenu>();
        getLevelHealth = FindObjectOfType<GetBuildingHealth>();
        cinemachineSwitch = FindObjectOfType<CinemachineSwitch>();
        winUI.SetActive(false);
        MotherTreeDestruction.onDestroyTree += WinGame;

        m_EventSystem = EventSystem.current;
    }

    private void Update()
    {
        if (getLevelHealth.level == Level.Level_2 && !level2GatesOpened)
        {
            level2GatesOpened = true;
            GateOpen(gate1, gate2);

            if (level)
            {
                StartCoroutine(cinemachineSwitch.GateCamera(gateCam1));
                level = false;
            }

        }

        if ( getLevelHealth.level == Level.Level_3 && !level3GatesOpened)
        {
            level3GatesOpened = true;
            GateOpen(gate3, gate4);

            if (level == false)
            {
                StartCoroutine(cinemachineSwitch.GateCamera(gateCam2));
                level = true;
            }
        }

    }

    public void GateOpen(Animator gate1, Animator gate2)
    {
        gate1.SetTrigger("GateOpenT");
        gate2.SetTrigger("GateOpenT");
    }
    public void WinGame()
    {
        cam.enabled = false;
        treeCam.enabled = true;

            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.03F * Time.timeScale;

            StartCoroutine(WinGame2());            
    }

    public IEnumerator WinGame2()
    {
        yield return new WaitForSeconds(1.5f);

        m_EventSystem.SetSelectedGameObject(itemsButton);
        pausMenu.winscreen = true;

        winUI.SetActive(true);
        globalVolumeController.TurnOnBlurr();
    }
}
