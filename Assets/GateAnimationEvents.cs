using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimationEvents : MonoBehaviour
{
    [SerializeField] GameObject[] particlePos;
    int emits = 10;
    public void OpenGateParticleFX()
    {
        StartCoroutine(DoDustParticlesSquence());
    }
    IEnumerator DoDustParticlesSquence()
    {
        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(particlePos[0].transform.position, emits);
        yield return new WaitForSeconds(0.15f);
        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(particlePos[1].transform.position, emits);
        yield return new WaitForSeconds(0.15f);
        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(particlePos[2].transform.position, emits);
        yield return new WaitForSeconds(0.15f);
        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(particlePos[3].transform.position, emits);
        yield return new WaitForSeconds(0.15f);
        ParticleSystemServiceLocator.Instance.GetDustParticleSystem().EmitParticles(particlePos[4].transform.position, emits);
    }
}
