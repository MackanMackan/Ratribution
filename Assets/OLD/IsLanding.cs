using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLanding : MonoBehaviour
{
    IntroLanding introLanding;
    private void Awake()
    {
        introLanding = FindObjectOfType<IntroLanding>();
        introLanding.landing = true;
        
    }

}
