using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemServiceLocator : MonoBehaviour
{
    public static ParticleSystemServiceLocator Instance { get { return instance; } }
    private static ParticleSystemServiceLocator instance;

    private IParticleSystem dustParticles;
    private IParticleSystem impactParticles;
    public GameObject dustParticleSystem;
    public GameObject impactParticleSystem;
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
    private void Start()
    {
        SetDustParticleSystem(new DustParticleSystem());
        SetImpactParticleSystem(new ImpactParticleSystem());
        dustParticles.SetParticleSystem(dustParticleSystem);
        impactParticles.SetParticleSystem(impactParticleSystem);
    }
    private void SetDustParticleSystem(IParticleSystem particleSystem)
    {
        dustParticles = particleSystem;
    }
    private void SetImpactParticleSystem(IParticleSystem particleSystem)
    {
        impactParticles = particleSystem;
    }
    public IParticleSystem GetDustParticleSystem()
    {
        return dustParticles;
    }public IParticleSystem GetImpactParticleSystem()
    {
        return impactParticles;
    }
}
