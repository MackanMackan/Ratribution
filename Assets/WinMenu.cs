using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public Image fade;
    [SerializeField] Image loadImg;
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
