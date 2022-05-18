using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Fade : MonoBehaviour

{
    public Image fade1;

    private void Awake()
    {
        DOTween.Init();

    }

    private void Start()
    {
        fade1.enabled = true;
        fade1.DOFade(0, 1f).SetUpdate(true).OnComplete(fadeOver);
    }

    private void fadeOver()
    {
        fade1.enabled = false;
    }
}
