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
        Debug.Log("HALLÅHALLÅ");
        DOTween.Init();

        fade1.enabled = true;
        fade1.DOFade(0, 1).SetUpdate(true).OnComplete(blabla); //Sätt alpha till 1, under 1 sekund, ignorera timescale, när det är klart kör funktionen Mm
    }

    private void blabla()
    {
        throw new NotImplementedException();
    }
}
