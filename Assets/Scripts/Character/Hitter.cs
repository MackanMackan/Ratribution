using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHitDestructable();
public class Hitter : MonoBehaviour
{
    public event onHitDestructable onHitDestructable;
    public int damage = 40;
    public float gizmoSizeSplit = 1f;

    [SerializeField] private CharacterAnimationImpact animImpact;
    [SerializeField] ParticleSystem shockWaveParticleSystem;
    private IDestructable destructableObj;
    Transform playerTransform;
    float amplitude = 5f;
    float frequency = 2f;
    float time = 0.4f;

    void Start()
    {
        onHitDestructable += DamageDestructableObject;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void DamageDestructableObject()
    {
        destructableObj.DamageMe(damage, gameObject, 0);

        CinemachineShake.Instance.BeginShake(amplitude, frequency, time);
        ServiceLocator.GetAudioProvider().PlayOneShot("StructureImpact", transform.position, true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDestructable>() != null)
        {
            destructableObj = other.GetComponent<IDestructable>();
            animImpact.PauseAnimationOnImpact(playerTransform,transform);
            onHitDestructable?.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.GetComponent<SphereCollider>().bounds.center, gameObject.GetComponent<SphereCollider>().radius / gizmoSizeSplit);
    }
}
