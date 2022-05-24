using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SkipIntroVideo : MonoBehaviour
{
    PlayerInputActions playerControls;
    InputAction roll;
    InputAction fire;
    InputAction dropbarrel;
    InputAction jump;
    InputAction anyKey;

    void Start()
    {
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

        roll.performed += GoToMainMenu;
        dropbarrel.performed += GoToMainMenu;
        jump.performed += GoToMainMenu;
        anyKey.performed += GoToMainMenu;
    }
    void GoToMainMenu(InputAction.CallbackContext callback)
    {
        roll.performed -= GoToMainMenu;
        dropbarrel.performed -= GoToMainMenu;
        jump.performed -= GoToMainMenu;
        anyKey.performed -= GoToMainMenu;

        roll.Disable();
        fire.Disable();
        dropbarrel.Disable();
        jump.Disable();
        anyKey.Disable();

        SceneManager.LoadScene("Menu");
    }
}
