using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    GameObject gate1;
    [SerializeField]
    GameObject gate2;

    GetBuildingHealth getLevelHealth;

    public GameObject winUI;

    float levelHealth;
    float speed = 10;
    

    private void Start()
    {
        getLevelHealth = FindObjectOfType<GetBuildingHealth>();
        winUI.SetActive(false);
    }

    private void Update()
    {
        if (getLevelHealth.level == Level.Level_2)
        { 
            GateOpen(gate1);
        }

        if ( getLevelHealth.level == Level.Level_3)
        {
            GateOpen(gate2);
        }

        if (getLevelHealth.level == Level.Level_4 || Input.GetMouseButtonDown (1))
        {
            winUI.SetActive(true);
           
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.03F * Time.timeScale;

        }
    }

    public void GateOpen(GameObject gate)
    {
        gate.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
