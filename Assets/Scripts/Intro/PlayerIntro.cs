using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    CharacterMovement characterMovement;
    IntroLanding introLanding;
    
    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterMovement.enabled = false;

        introLanding = GameObject.Find("TriggerBoxLanding").GetComponent<IntroLanding>();
    }

    private void Update()
    {
        if (introLanding.landing)
        {
            characterMovement.enabled = true;
        }
    }
}
