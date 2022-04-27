using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] static int health = 50;
   
    public static void DamageMe(int damage)
    {
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }
}
