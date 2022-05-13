using UnityEngine;

public class SpearFly : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject trail;
    [SerializeField] float throwForce = 10;
    [SerializeField] BoxCollider spearCollider;
    void Start()
    {
        Vector3 direction = CharacterGetter.PLAYER.transform.position - transform.position;
        direction.Normalize();
        direction.y = Random.Range(0.5f,0.7f);
        rb.AddForce(direction * throwForce, ForceMode.VelocityChange);
        transform.LookAt(CharacterGetter.PLAYER.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
        Destroy(gameObject,10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLimb"))
        {
            transform.SetParent(other.transform);
            CharacterHealth.DamageMe(2);
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            spearCollider.enabled = false;
            trail.SetActive(false);
        }
    }
}
