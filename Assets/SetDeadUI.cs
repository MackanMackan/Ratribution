using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SetDeadUI : MonoBehaviour
{
    public Image fade;
    Animator playerAnimator;
    GameObject player;

    void Start()
    {
        CharacterHealth.onDeadPlayer += ActivateDead;
        StartCoroutine(nameof(GetPlayerRef));
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(2f);
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponentInChildren<Animator>();
    }
    void ActivateDead()
    {
        playerAnimator.SetBool("isDead", true);
        fade.enabled = true;
        fade.DOFade(1, 3).SetUpdate(true).OnComplete(LoadDeadScene);
    }
    void LoadDeadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
