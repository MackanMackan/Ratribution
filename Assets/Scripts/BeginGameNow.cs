using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class BeginGameNow : MonoBehaviour
{
    public Image fade;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                
            Game();
                      
        }

    }

    public void Game()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).SetUpdate(true).OnComplete(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
