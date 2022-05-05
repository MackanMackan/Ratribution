using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGetter : MonoBehaviour
{
    public static GameObject PLAYER;
    void Start()
    {
        PLAYER = gameObject;
    }
}
