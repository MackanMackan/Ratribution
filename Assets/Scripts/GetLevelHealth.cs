using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelHealth : MonoBehaviour
{
    public enum Level
    {
        Level_1,
        Level_2,
        Level_3,
    }

    public Level level;
    [SerializeField]
    GameObject levelHolder_1;
    [SerializeField]
    GameObject levelHolder_2;
    [SerializeField]
    GameObject levelHolder_3;

    DestructionCount destructionCount;
    BuildingCrumble buildingCrumble;

    public float totalHealth;


    void Start()
    {
        level = Level.Level_1;
        destructionCount = FindObjectOfType<DestructionCount>();
        destructionCount.SetStartTotalHealth(GetCurrentHealth());      
    }

    void Update()
    {
        destructionCount.SetCurrentHealth(GetCurrentHealth());
    }

    private float GetCurrentHealth()
    {
         totalHealth = 0;

        if (level == Level.Level_1)
        {
            Metod(levelHolder_1);

            if (totalHealth <= 0)
            {
                level = Level.Level_2;
            }
        }

        if (level == Level.Level_2)
        {
            Metod(levelHolder_2);

            if (totalHealth <= 0)
            {
                level = Level.Level_3;
            }
        }

        if (level == Level.Level_3)
        {
            Metod(levelHolder_3);

            if (totalHealth <= 0)
            {
                //WINNING
            }
        }

        return totalHealth;
    }

    public void Metod(GameObject level)
    {       
        List<GameObject> children = level.GetChildren();

        foreach (GameObject child in children)
        {
            buildingCrumble = child.GetComponent<BuildingCrumble>();
            if (buildingCrumble != null)
                totalHealth += buildingCrumble.health;
        }
    }
}
