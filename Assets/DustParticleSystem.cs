using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleSystem : MonoBehaviour
{
    public static DustParticleSystem Instance { get { return instance; } }
    private static DustParticleSystem instance;
    public GameObject dustParticleSystem;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void EmitDustParticles(Vector3 position, int emits)
    {
        dustParticleSystem = InstanciateParticleSystem();
        dustParticleSystem.transform.position = position;
        ParticleSystem particles = dustParticleSystem.GetComponent<ParticleSystem>();
        particles.Emit(emits);
    }

    private GameObject InstanciateParticleSystem()
    {
        return Instantiate(dustParticleSystem);
    }
}
