using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelPickUp : MonoBehaviour
{
    bool pickedUpBarrel = false;
    bool inMotherTreeZone = false;
    [SerializeField] GameObject barrelHolder;
    [SerializeField] GameObject barrelDropper;
    PlayerInputActions playerControls;
    InputAction dropBarrel;
    GameObject barrel;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
        dropBarrel = playerControls.Player.DropBarrel;
        dropBarrel.performed += DropBarrel;
    }
    private void OnEnable()
    {
        dropBarrel.Enable();
    }
    private void OnDisable()
    {
        dropBarrel.Disable();
    }
    void DropBarrel(InputAction.CallbackContext call)
    {
        if (pickedUpBarrel)
        {
            barrel.transform.position = barrelDropper.transform.position;
            barrel.transform.rotation = barrelDropper.transform.rotation;
            barrel.transform.SetParent(null);
            barrel.GetComponent<CapsuleCollider>().enabled = true;
            barrel.GetComponent<Rigidbody>().isKinematic = false;

            if(!inMotherTreeZone)
                barrel.GetComponent<ExplodeBarrel>().StartExplosionFuse();

            barrel = null;
            pickedUpBarrel = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup") && !pickedUpBarrel && !other.GetComponent<ExplodeBarrel>().isExploding)
        {
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = barrelHolder.transform.position;
            other.transform.rotation = barrelHolder.transform.rotation;
            other.transform.SetParent(barrelHolder.transform);
            pickedUpBarrel = true;
            barrel = other.gameObject;
        }
        if (other.CompareTag("MotherTree"))
        {
            inMotherTreeZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MotherTree"))
        {
            inMotherTreeZone = false;
        }
    }
}
