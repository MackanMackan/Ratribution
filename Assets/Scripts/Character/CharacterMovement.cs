using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Vector2 moveDir;
    private float targetAngle;

    private Transform CharaCam;

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
        CharaCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
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
        CameraLookRotation();
        Movement();
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(moveDir.x, 0, moveDir.y);

    }
    private void CameraLookRotation()
    {
        //Rotate towards input dir.
        targetAngle = Mathf.Atan2(GetMoveInput().x, GetMoveInput().z) * Mathf.Rad2Deg + CharaCam.eulerAngles.y;
    }
    private void Rotation()
    {
        if (moveDir != Vector2.zero)
        {
            //Vector3 m = moveDir;
            Vector3 m = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            m.z = m.y;
            m.y = 0;
            Quaternion q = Quaternion.LookRotation(m, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * 6);
        }
    }

    private void Movement()
    {
        Rotation();
        Vector3 m = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        Vector3 resetV = new Vector3(0, rb.velocity.y, 0);
        
        
        if (GetMoveInput().magnitude >= 0.1f)
        {
            rb.AddForce(playerSpeed * Time.deltaTime * m, ForceMode.VelocityChange);
            //rb.velocity = m * playerSpeed;
        }
        else
        {
            //rb.velocity = Vector3.Lerp(rb.velocity, resetV, 5f);
        }
    }
}
