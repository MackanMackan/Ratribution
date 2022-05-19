using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Level_1,
    Level_2,
    Level_3,
    Level_4,
}

public class GetBuildingHealth : MonoBehaviour
{
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
        RestartBuildingHealth();    
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
            LoopToGetHealth(levelHolder_1);
            if (totalHealth <= 0)
            {
                level = Level.Level_2;
                RestartBuildingHealth();
            }
        }

        if (level == Level.Level_2)
        {
            LoopToGetHealth(levelHolder_2);
            if (totalHealth <= 0)
            {
                level = Level.Level_3;
                RestartBuildingHealth();
            }
        }

        if (level == Level.Level_3)
        {
            LoopToGetHealth(levelHolder_3);
            if (totalHealth <= 0)
            {
                level = Level.Level_4;
            }
        }

        return totalHealth;
    }

    public void LoopToGetHealth(GameObject level)
    {       
        List<GameObject> children = level.GetChildren();

        foreach (GameObject child in children)
        {
            buildingCrumble = child.GetComponent<BuildingCrumble>();
            if (buildingCrumble != null)
                totalHealth += buildingCrumble.health;
        }
    }

    public void RestartBuildingHealth()
    {
        destructionCount.SetStartTotalHealth(GetCurrentHealth());
    }
}
