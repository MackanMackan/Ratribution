using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GlobalVolumeController : MonoBehaviour
{
    [HideInInspector]
    public VolumeProfile profile;
    public Volume m_Volume;

    GetBuildingHealth getLevelHealth;

    private void Start()
    {
        profile = m_Volume.sharedProfile;
        if (!profile.TryGet<DepthOfField>(out var depthOfField))
        {
            depthOfField = profile.Add<DepthOfField>(false);
        }

        depthOfField.active = false;

        getLevelHealth = FindObjectOfType<GetBuildingHealth>();

        MotherTreeDestruction.onDestroyTree += TurnOnBlurr;
    }


    public void TurnOnBlurr()
    {
        profile.TryGet<DepthOfField>(out var depthOfField);

        depthOfField.active = true;      
    }

    public void TurnOffBlurr()
    {
        profile.TryGet<DepthOfField>(out var depthOfField);

        depthOfField.active = false;
    }

}
