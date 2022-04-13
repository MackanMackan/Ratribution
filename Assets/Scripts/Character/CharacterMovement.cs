using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Vector2 moveDir;
    private Vector2 LookDir;

    private PlayerInputActions playerControls;
    private InputAction moveInput;

    private Rigidbody rb;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        moveInput = playerControls.Player.Move;

        //Movement
        moveInput.performed += cntxt => moveDir = cntxt.ReadValue<Vector2>();
        moveInput.canceled += cntxt => moveDir = Vector2.zero;

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        Vector3 m = new Vector3(moveDir.x * playerSpeed, 0, moveDir.y * playerSpeed);
        rb.velocity = m;
    }
    private void Rotation()
    {
        Vector3 ld = (Vector3)moveDir + transform.position;

        if (moveDir != Vector2.zero)
        {

            Vector3 m = moveDir;
            m.z = m.y;
            m.y = 0;
            Quaternion q = Quaternion.LookRotation(m, Vector3.up);
            transform.rotation = q;
            Debug.Log(moveDir);
        }
    }


}
