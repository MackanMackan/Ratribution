using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.UI;
using DG.Tweening;

public class SkipIntroVideo : MonoBehaviour
{
    [SerializeField] Image fadeImg;

    PlayerInputActions playerControls;
    InputAction roll;
    InputAction fire;
    InputAction dropbarrel;
    InputAction jump;
    InputAction anyKey;

    VideoPlayer vidPlayer;
    void Start()
    {
        vidPlayer = GetComponent<VideoPlayer>();
        playerControls = new PlayerInputActions();
        roll = playerControls.Player.Roll;
        fire = playerControls.Player.Fire;
        dropbarrel = playerControls.Player.DropBarrel;
        jump = playerControls.Player.Jump;
        anyKey = playerControls.Player.AnyKey;

        roll.Enable();
        dropbarrel.Enable();
        jump.Enable();
        anyKey.Enable();

        roll.performed += SkipButtonPushed;
        dropbarrel.performed += SkipButtonPushed;
        jump.performed += SkipButtonPushed;
        anyKey.performed += SkipButtonPushed;

        vidPlayer.loopPointReached += IntroCutsceneFinished;
    }
    void SkipButtonPushed(InputAction.CallbackContext callback)
    {
        RemoveEvents();

        DisableInput();

        DoFadeScreen();
    }
    void IntroCutsceneFinished(VideoPlayer player)
    {
        RemoveEvents();

        DisableInput();

        DoFadeScreen();
    }
    void RemoveEvents()
    {
        roll.performed -= SkipButtonPushed;
        dropbarrel.performed -= SkipButtonPushed;
        jump.performed -= SkipButtonPushed;
        anyKey.performed -= SkipButtonPushed;
        vidPlayer.loopPointReached -= IntroCutsceneFinished;
    }
    void DisableInput()
    {
        roll.Disable();
        fire.Disable();
        dropbarrel.Disable();
        jump.Disable();
        anyKey.Disable();
    }
    void DoFadeScreen()
    {
        fadeImg.enabled = true;
        fadeImg.DOFade(1, 2).SetUpdate(true).OnComplete(LoadMainMenu);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
