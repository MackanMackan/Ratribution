using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXDestroyer : MonoBehaviour
{
    VisualEffect vfx;
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
        StartCoroutine(DestroyVFX());
    }


    IEnumerator DestroyVFX()
    {
        yield return new WaitForSeconds(0.5f);
        if (vfx.aliveParticleCount == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyVFX());
        }
    }
}
