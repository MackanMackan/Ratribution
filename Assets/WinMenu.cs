using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WinMenu : MonoBehaviour
{
    public Image fade;
    public Image fade2;
    [SerializeField] Image loadImg;
    public Ease ease = Ease.InCubic;

    private void Start()
    {
        fade2.DOFade(0, 3f).SetDelay(0.5f).SetEase(ease).OnComplete(fadeOver);
    }

    private void fadeOver()
    {
        fade2.enabled = false;
    }

    private void WinScene()
    {
        throw new NotImplementedException();
    }

    public void BackToMainMenu()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).SetUpdate(true).OnComplete(Mm);
    }

    public void Mm()
    {
        Time.timeScale = 1f;
        loadImg.enabled = true;
        SceneManager.LoadScene("Menu");
    }
}
