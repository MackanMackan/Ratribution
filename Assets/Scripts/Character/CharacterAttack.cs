using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private InputAction actionInput;

    [SerializeField] GameObject hitter;
    [SerializeField] GameObject animatorParentObj;
    Hitter hitterScript;

    private Animator animator;

    private Rigidbody hitterRB;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        actionInput = playerControls.Player.Fire;
    }

    private void Start()
    {
        hitterRB = hitter.GetComponent<Rigidbody>();
        hitter.SetActive(false);

        animator = animatorParentObj.GetComponent<Animator>();

        actionInput.performed += MeleeAttack;
    }

    private void OnEnable()
    {
        actionInput.Enable();
    }

    private void OnDisable()
    {
        actionInput.Disable();
    }

    private void MeleeAttack(InputAction.CallbackContext callbackContext)
    {
        hitter.SetActive(true);
        animator.SetTrigger("PunchT");

        if (hitterScript == null)
            hitterScript = hitter.GetComponent<Hitter>();

        hitterScript.GetNewHitID();
    }
    public void TurnOffPunch()
    {
        hitter.SetActive(false);
    }

}
