using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening; 
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject creditsUI;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject backButton;
    public Image fade;


    private void Awake()
    {
        DOTween.Init();
    }
    private void Start()
    {
        creditsUI.SetActive(false);
    }

    public void Fade1()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).SetUpdate(true).OnComplete(PlayGame); //S�tt alpha till 1, under 1 sekund, ignorera timescale, n�r det �r klart k�r funktionen Mm
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);  
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void GoToTut()
    {
        SceneManager.LoadScene(1);

    }

    public void GoToCredits()
    {
        pauseMenuUI.SetActive(false);
        creditsUI.SetActive(true);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(backButton, new BaseEventData(eventSystem));
    }

    public void BackToMainMenu()
    {
        pauseMenuUI.SetActive(true);
        creditsUI.SetActive(false);
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(playButton, new BaseEventData(eventSystem));
    }


}
