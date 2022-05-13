using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBarrel : MonoBehaviour
{
    public bool isExploding = false;
    [SerializeField] float timerUntilExploder = 3;
    [SerializeField] GameObject particleFuse;
    [SerializeField] GameObject explosionHitter;
    [SerializeField] SphereCollider explosionCollider;
    public void StartExplosionFuse()
    {
        isExploding = true;
        particleFuse.SetActive(true);
        StartCoroutine(ExplosionCountDown());
    }
    IEnumerator ExplosionCountDown()
    {
        yield return new WaitForSeconds(timerUntilExploder);
        explosionHitter.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Explode();
    }

    private void Explode()
    {
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("BarrelExplosion", transform.position, true);
        explosionCollider.enabled = false;
        Destroy(gameObject,15);
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}
