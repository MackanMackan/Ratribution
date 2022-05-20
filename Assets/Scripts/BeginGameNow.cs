using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BeginGameNow : MonoBehaviour
{
    public Image fade;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fade.enabled = true;
            fade.DOFade(1, 1).SetUpdate(true).OnComplete(StartGame);           
        }
    }
    void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
