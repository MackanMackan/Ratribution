using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Fade : MonoBehaviour

{
    public Image fade1;

    private void Start()
    {
        //fade1.enabled = true;
        fade1.DOFade (0, 3).SetDelay(1).OnComplete(fadeOver);
    }

    private void fadeOver()
    {
        fade1.enabled = false;
    }
}
