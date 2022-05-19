using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Fade : MonoBehaviour

{
    public Image fade1;
    public Ease ease = Ease.InCubic;

    private void Start()
    {
        fade1.DOFade (0, 3f).SetDelay(0.5f).SetEase(ease).OnComplete(fadeOver);
    }

    private void fadeOver()
    {
        fade1.enabled = false;
    }
}
