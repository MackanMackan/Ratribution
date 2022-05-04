using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFly : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float throwForce = 10;
    void Start()
    {
        Vector3 direction = CharacterGetter.PLAYER.transform.position - transform.position;
        direction.Normalize();
        direction.y = 1.2f;
        rb.AddForce(direction * throwForce, ForceMode.VelocityChange);
    }
    private void Update()
    {
        transform.LookAt(CharacterGetter.PLAYER.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLimb"))
        {
            transform.SetParent(other.transform);
            CharacterHealth.DamageMe(2);
        }
    }
}
