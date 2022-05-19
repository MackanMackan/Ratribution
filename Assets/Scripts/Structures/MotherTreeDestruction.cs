using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onDestroyTree();
public class MotherTreeDestruction : MonoBehaviour
{
    public static event onDestroyTree onDestroyTree;
    [SerializeField] GameObject[] barrelHolders;
    [SerializeField] Rigidbody rb;
    List<GameObject> barrels;
    public int amountOfBarrelsAttached = 0;

    private void Start()
    {
        barrels = new List<GameObject>();
    }
    public void AddBarrelToTree(GameObject other)
    {
        if(barrels != null)
        {
            foreach (var barrel in barrels)
            {
                if (other.name.Equals(barrel.name))
                {
                    return;
                }
            }
        }
        barrels.Add(other.gameObject);
        other.transform.position = barrelHolders[amountOfBarrelsAttached].transform.position;
        other.transform.localScale *= 4f;
        other.transform.rotation = barrelHolders[amountOfBarrelsAttached].transform.rotation;
        other.transform.SetParent(barrelHolders[amountOfBarrelsAttached].transform);
        other.GetComponent<ExplodeBarrel>().isExploding = true;
        other.GetComponent<Rigidbody>().isKinematic = true;
        amountOfBarrelsAttached++;

        if (amountOfBarrelsAttached == 3)
        {
            foreach (var barrel in barrels)
            {
                barrel.GetComponent<ExplodeBarrel>().StartExplosionFuse();
            }
            StartCoroutine(TurnOnPhysics());
        }
}
    private void OnTriggerEnter(Collider other)
    {
           
    }
    IEnumerator TurnOnPhysics()
    {
        yield return new WaitForSeconds(3f);
        rb.isKinematic = false;
        rb.velocity = new Vector3(0, 5, 0);
        onDestroyTree?.Invoke();
    }
}
