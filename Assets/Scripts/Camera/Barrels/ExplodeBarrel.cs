using System;
using System.Collections;
using UnityEngine;

public class ExplodeBarrel : MonoBehaviour
{
    public bool isExploding = false;
    [SerializeField] float timeUntilExplode = 3;
    [SerializeField] GameObject particleFuse;
    [SerializeField] GameObject explosionHitter;
    [SerializeField] SphereCollider explosionCollider;
    [SerializeField] AudioSource source;
    public void StartExplosionFuse()
    {
        isExploding = true;
        particleFuse.SetActive(true);
        StartCoroutine(ExplosionCountDown());
    }
    IEnumerator ExplosionCountDown()
    {
        yield return new WaitForSeconds(timeUntilExplode);
        explosionHitter.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Explode();
    }

    private void Explode()
    {
        source.pitch = UnityEngine.Random.Range(0.8f,1.2f);
        source.Play();
        explosionCollider.enabled = false;
        Destroy(gameObject,15);
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}
