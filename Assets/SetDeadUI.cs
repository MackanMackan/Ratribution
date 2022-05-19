using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDeadUI : MonoBehaviour
{
    [SerializeField] GameObject deadUI;
    void Start()
    {
        CharacterHealth.onDeadPlayer += ActivateDeadUI;
    }
    void ActivateDeadUI()
    {
        deadUI.SetActive(true);
    }
}
