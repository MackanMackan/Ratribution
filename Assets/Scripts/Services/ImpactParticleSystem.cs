using UnityEngine;

class ImpactParticleSystem : IParticleSystem
{
    GameObject impactParticleSystem;
     public void EmitParticles(Vector3 position, int emits)
    {
        GameObject dustParticleSystemInstance = InstatiateParticleSystem();
        dustParticleSystemInstance.transform.position = position;
        ParticleSystem particles = dustParticleSystemInstance.GetComponent<ParticleSystem>();
        particles.Emit(emits);
    }

        public GameObject InstatiateParticleSystem()
    {
        return MonoBehaviour.Instantiate(impactParticleSystem);
    }

    public void SetParticleSystem(GameObject particleSystem)
    {
        impactParticleSystem = particleSystem;
    }
}