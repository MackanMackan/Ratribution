using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherPoofParticleSystem : IParticleSystem
{
    public GameObject particleSystem;

    public void EmitParticles(Vector3 position, int emits)
    {
        GameObject particleInstance = InstatiateParticleSystem();
        particleInstance.transform.position = position;
        ParticleSystem poofParticles = particleInstance.GetComponent<ParticleSystem>();
        poofParticles.Emit(emits);
        ParticleSystem particles = particleInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
        particles.Emit(emits);

    }
    public GameObject GetNewParticleSystem()
    {
        GameObject particleInstance = InstatiateParticleSystem();
        return particleInstance;
    }
    public GameObject InstatiateParticleSystem()
    {
        return MonoBehaviour.Instantiate(particleSystem);
    }

    public void SetParticleSystem(GameObject particleSystem)
    {
        this.particleSystem = particleSystem;
    }
}
