using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject creditsUI;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject backButton;

    private void Start()
    {
        creditsUI.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        //MusicSound.PlayMenuMusic();
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
