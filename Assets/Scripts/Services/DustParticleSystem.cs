using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleSystem : IParticleSystem
{
    public GameObject dustParticleSystem;

    public void EmitParticles(Vector3 position, int emits)
    {
        GameObject dustParticleSystemInstance = InstatiateParticleSystem();
        dustParticleSystemInstance.transform.position = position;
        ParticleSystem particles = dustParticleSystemInstance.GetComponent<ParticleSystem>();
        particles.Emit(emits);
    }
    public GameObject GetNewParticleSystem()
    {
        GameObject dustParticleSystemInstance = InstatiateParticleSystem();
        return dustParticleSystemInstance;
    }
    public GameObject InstatiateParticleSystem()
    {
        return MonoBehaviour.Instantiate(dustParticleSystem);
    }

    public void SetParticleSystem(GameObject particleSystem)
    {
        dustParticleSystem = particleSystem;
    }
}
