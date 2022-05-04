using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSpear : MonoBehaviour
{
    [SerializeField] GameObject spearThrown;
    [SerializeField] GameObject spear;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootSpear()
    {
        GameObject insSpear = Instantiate(spearThrown, spear.transform.position,Quaternion.identity);
    }
}
