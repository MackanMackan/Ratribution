using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    GlobalVolumeController globalVolumeController;
    private PlayerInputActions playerControls;
    public Animator transision;
    private float transisionTime;

    private void Awake()
    {
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
        if (playerControls.UI.Menu.triggered) //TO DO LAGG TILL KONTROLL
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        globalVolumeController.TurnOffBlurr();
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        globalVolumeController.TurnOnBlurr();
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        transision.SetTrigger("Start");
        Invoke(nameof(Mm), 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Mm()
    {
        SceneManager.LoadScene(0);
    }

}
