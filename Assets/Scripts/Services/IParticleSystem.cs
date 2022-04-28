using UnityEngine;
public interface IParticleSystem
{
    public void EmitParticles(Vector3 position, int emits);
    public GameObject GetNewParticleSystem();
    public GameObject InstatiateParticleSystem();
    public void SetParticleSystem(GameObject particleSystem);
}