using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] static int health;
   
    public static void DamageMe(int damage)
    {
        health -= damage;
    }
}
