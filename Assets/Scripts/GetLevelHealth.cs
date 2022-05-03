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
    // [SerializeField]
    //GameObject levelHolder_2;
    //[SerializeField]
    //GameObject levelHolder_3;

    DestructionCount destructionCount;
    BuildingCrumble buildingCrumble;

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
        int totalHealth = 0;
        if (level == Level.Level_1)
        {
            List<GameObject> children = levelHolder_1.GetChildren();

            foreach (GameObject child in children)
            {
                buildingCrumble = child.GetComponent<BuildingCrumble>();
                if (buildingCrumble != null)
                    totalHealth += buildingCrumble.health;
            }           
        }

        return totalHealth;
    }
}
