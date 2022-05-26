using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class tut_menu : MonoBehaviour
{
    private PlayerInputActions playerControls;
    public GameObject backUI;
    public static bool gameIsPaused = false;
    public Image fade;
    [SerializeField] Image loadImg;
    public GameObject back;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        backUI.SetActive(false);
    }
    void Update()
    {
        if (playerControls.UI.Menu.triggered)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                //var eventSystem = EventSystem.current;
                //eventSystem.SetSelectedGameObject(back, new BaseEventData(eventSystem));              
            }
        }
    }
    void Pause()
    {
        
        backUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
    }
    public void Resume()
    {
        backUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void BackToMainMenu()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).SetUpdate(true).OnComplete(Mmm);
    }
    public void Mmm()
    {
        Time.timeScale = 1f;
        loadImg.enabled = true;
        SceneManager.LoadScene("Menu");
    }
    public void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
