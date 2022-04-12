using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onHitDestructable();
public class Hitter : MonoBehaviour
{
    public static event onHitDestructable onHitDestructable;
    public int damage = 40;

    Vector3 hitDir;
    Vector3 oldHitDir;

    private IDestructable destructableObj;
    void Start()
    {
        onHitDestructable += DamageDestructableObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DamageDestructableObject()
    {
        StartCoroutine(CalculateHitDirection());
        destructableObj.DamageMe(damage);
    }
    IEnumerator CalculateHitDirection()
    {
        oldHitDir = transform.position;
        yield return new WaitForSeconds(0.2f);
        hitDir = oldHitDir - transform.position;
        hitDir.Normalize();
        destructableObj.GetHitDirection(hitDir);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDestructable>() != null)
        {
            destructableObj = other.GetComponent<IDestructable>();
            onHitDestructable?.Invoke();
        }
    }
}
