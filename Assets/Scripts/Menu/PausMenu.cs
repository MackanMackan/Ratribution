using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PausMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    GlobalVolumeController globalVolumeController;
    private PlayerInputActions playerControls;
    public Image fade; //Istället för transition
    private float transisionTime;
    [SerializeField]
    AudioSource audioSource;
    [HideInInspector]
   public bool winscreen = false;
    public GameObject cButton;

    [SerializeField] Image loadImg;
    private void Awake()
    {
        DOTween.Init();
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {

        pauseMenuUI.SetActive(false);
       globalVolumeController= FindObjectOfType<GlobalVolumeController>();
        
    }

    public void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        if (playerControls.UI.Menu.triggered && !winscreen) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {             
                Pause();                            
            }
        }
    }

    public void Resume()
    {
        audioSource.volume = 0.5f;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        globalVolumeController.TurnOffBlurr();
    }
    void Pause()
    {
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(cButton, new BaseEventData(eventSystem));
        audioSource.volume = 0.2f;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        globalVolumeController.TurnOnBlurr();
    }

    public void Restart()
    {
        loadImg.enabled = true;
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f;
    }
    public void BackToMainMenu()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).SetUpdate(true).OnComplete(Mm); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Mm()
    {
        Time.timeScale = 1f;
        loadImg.enabled = true;
        SceneManager.LoadScene("Menu");
    }

}
