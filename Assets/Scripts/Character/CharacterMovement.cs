using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Vector2 moveDir;
    private float targetAngle;

    [SerializeField] Transform CharaCam;

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
    }


    private Vector3 GetMoveInput()
    {
        return new Vector3(moveDir.x, 0.0f, moveDir.y);

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
            Vector3 m = moveDir;
            m.z = m.y;
            m.y = 0;
            Quaternion q = Quaternion.LookRotation(m, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, q, Time.deltaTime * 6);
            Debug.Log(moveDir);
        }
    }

    private void Movement()
    {
        //CameraLookRotation();
        Rotation();
        Vector3 m = new Vector3(moveDir.x * playerSpeed, 0, moveDir.y * playerSpeed);
        rb.velocity = m;

        //Vector3 m = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //rb.AddForce(m * playerSpeed * Time.deltaTime);
    }
}
